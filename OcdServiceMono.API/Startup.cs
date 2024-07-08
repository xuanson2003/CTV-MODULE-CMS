using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using OcdServiceMono.API.Service;
using OcdServiceMono.API.Infrastructure;
using OcdServiceMono.API.Infrastructure.Authentication;
using OcdServiceMono.Lib.Core;
using OcdServiceMono.Lib.Interfaces;
using System;
using System.IO;
using System.Text;
using OcdServiceMono.API.Infrastructure.BackgroundTasks;
using OcdServiceMono.API.Infrastructure.Swagger;
using OcdServiceMono.API.Infrastructure.DbContexts;
using OcdServiceMono.API.Infrastructure.Middleware;
using MassTransit;
using OcdServiceMono.API.Consumers;
using static System.Runtime.InteropServices.JavaScript.JSType;
using RabbitMQ.Client;
using OcdServiceMono.API.Models.Message;

namespace OcdServiceMono.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            AppSettings = new AppSettings();
            Configuration.Bind(AppSettings);
        }

        public IConfiguration Configuration { get; }
        private AppSettings AppSettings { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyOrigin", builder => builder
                    .SetIsOriginAllowed(_ => true)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
            services.AddControllers();
            services.AddMemoryCache();
            ConfigureSwaggerService(services);
            //ConfigureMassTransit(services);
            services.AddDbContext<ReadDomainDbContext>();
            services.AddDbContext<WriteDomainDbContext>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
            services.AddScoped(typeof(IServiceWrapper), typeof(ServiceWrapper));
            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            });

            ConfigureAuthService(services);
            services.AddHostedService<TimedHostedService>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<FillterTenantMiddleware>();
            ConfigureSwagger(app);
            app.UseRouting();
            app.UseCors("AllowAnyOrigin");
            ConfigureFileServer(app);
            ConfigureAuth(app);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        #region Auth
        private void ConfigureAuthService(IServiceCollection services)
        {
            var jwtTokenConfig = Configuration.GetSection("IdentityServerAuthentication").Get<IdentityServerAuthentication>();
            var googleAuthentication = Configuration.GetSection("IdentityServerAuthentication").Get<GoogleAuthentication>();
            var facebookAuthentication = Configuration.GetSection("IdentityServerAuthentication").Get<FacebookAuthentication>();
            services.AddSingleton(jwtTokenConfig);
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            //.AddGoogle(googleOptions =>
            //{
            //    googleOptions.ClientId = googleAuthentication.ClientId;
            //    googleOptions.ClientSecret = googleAuthentication.ClientSecret;
            //})
            //.AddFacebook(facebookOptions =>
            //{
            //    facebookOptions.ClientId = googleAuthentication.ClientId;
            //    facebookOptions.ClientSecret = googleAuthentication.ClientSecret;
            //})
            .AddJwtBearer(x =>
            {
                //x.Authority = AppSettings.IdentityServerAuthentication.Authority;
                //x.Audience = AppSettings.IdentityServerAuthentication.ApiName;
                x.RequireHttpsMetadata = AppSettings.IdentityServerAuthentication.RequireHttpsMetadata;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AppSettings.IdentityServerAuthentication.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AppSettings.IdentityServerAuthentication.Secret)),
                    ValidAudience = AppSettings.IdentityServerAuthentication.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
        }
        protected virtual void ConfigureAuth(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
        #endregion
        #region MassTransit
        private void ConfigureMassTransit(IServiceCollection services)
        {
            string my_queue = "my_queue";
            string my_queue_Direct = "my_queue_Direct";
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(AppSettings.RabbitMQConfig.Host, AppSettings.RabbitMQConfig.Port, AppSettings.RabbitMQConfig.VirtualHost, h => {
                        h.Username(AppSettings.RabbitMQConfig.Username);
                        h.Password(AppSettings.RabbitMQConfig.Password);
                    });

                    cfg.ReceiveEndpoint(my_queue, e =>
                    {
                        e.PrefetchCount = 16;
                        e.UseMessageRetry(x => x.Interval(2, 100));
                        e.Consumer<MessageConsumer>();
                    });

                    cfg.Send<SimpleMessage_Direct>(x =>
                    {
                        x.UseRoutingKeyFormatter(context => context.Message.Type);
                    });
                    cfg.Message<SimpleMessage_Direct>(x => x.SetEntityName("group_name"));
                    cfg.Publish<SimpleMessage_Direct>(x => x.ExchangeType = ExchangeType.Direct);

                    cfg.ReceiveEndpoint("active_" + my_queue_Direct, e =>
                    {
                        e.PrefetchCount = 16;
                        e.UseMessageRetry(x => x.Interval(2, 100));
                        e.ConfigureConsumeTopology = false;
                        e.Consumer<MessageConsumer_Direct>();
                        e.Bind("group_name", s =>
                        {
                            s.RoutingKey = "active";
                            s.ExchangeType = ExchangeType.Direct;
                        });
                    });

                    cfg.ReceiveEndpoint("inActive_" + my_queue_Direct, e =>
                    {
                        e.PrefetchCount = 16;
                        e.UseMessageRetry(x => x.Interval(2, 100));
                        e.ConfigureConsumeTopology = false;
                        e.Consumer<MessageConsumer_Direct>();
                        e.Bind("group_name", s =>
                        {
                            s.RoutingKey = "inActive";
                            s.ExchangeType = ExchangeType.Direct;
                        });
                    });

                });
            });

            services.Configure<MassTransitHostOptions>(options =>
            {
                options.WaitUntilStarted = true;
                options.StartTimeout = TimeSpan.FromSeconds(30);
                options.StopTimeout = TimeSpan.FromMinutes(1);
            });
        }
        #endregion
        #region Swagger
        private void ConfigureSwaggerService(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OcdServiceMono" +
                    "" +
                    "" +
                    "" +
                    "", Version = "v1" });
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
                c.CustomSchemaIds(i => i.FullName);
                c.SchemaFilter<SwaggerExcludeFilter>();
            });
        }
        protected virtual void ConfigureSwagger(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();//swagger
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OcdServiceMono-v1"));
        }
        #endregion
        #region FileServer
        protected virtual void ConfigureFileServer(IApplicationBuilder app)
        {
            string root = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles");
            if (!File.Exists(root))
            {
                Directory.CreateDirectory(root);
            }
            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(root),
                RequestPath = "/StaticFiles",
                EnableDefaultFiles = true
            });
        }
        #endregion

    }
}