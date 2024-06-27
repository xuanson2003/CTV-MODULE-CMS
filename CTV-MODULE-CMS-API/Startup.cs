
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Authorization;

//namespace CTV_MODULE_CMS_API
//{
//    public class Startup
//    {
//        public void ConfigureServices(IServiceCollection services)
//        {
//            // Dang ky cac dich vu
//            services.AddControllers();
//        }

//        // Xay dung cac pineline(chuoi cac middleware): cac doan code http chay qua, xu ly va tra ve response
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//        {
//            // http message(request) luc nao cung phai di qua endpointroutingmiddleware
//            // dieu huong request di toi 1 endpoint nhat dinh, neu nhu routing ko phu hop
//            // thi request se di chuyen xuong terminal middleware

//            app.UseRouting();  // middleware

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapGet("/", async (context) =>
//                {
//                    await context.Response.WriteAsync("Day la trang chu");
//                });

//                endpoints.MapGet("/about", async (context) =>
//                {
//                    await context.Response.WriteAsync("Thong tin ve chung toi: ...");
//                });

//                endpoints.MapGet("/contact", async (context) =>
//                {
//                    await context.Response.WriteAsync("Lien he voi chung toi: 0906 114 945");
//                });

//                endpoints.MapGet("/service/price", async (context) =>
//                {
//                    await context.Response.WriteAsync("Gia ca dich vu...");
//                });
//            });

//            app.Map("/abc", app1 =>
//            {
//                app1.Run(async (HttpContext context) =>
//                {
//                    await context.Response.WriteAsync("Noi dung tra ve tu endpoint ABC!");
//                });
//            });

//            // terminal middleware: dia chi tra ve cuoi cung
//            //app.run(async (httpcontext context) => {  // bat dong bo, tra ve task, await
//            //    await context.response.writeasync("xin chao, day la start up!");
//            //} );

//            // page not found
//            app.UseStatusCodePages();

//            //if (env.IsDevelopment())
//            //{
//            //    app.UseDeveloperExceptionPage();
//            //}

//            //app.UseHttpsRedirection();
//            //app.UseRouting();
//            //app.UseAuthorization();
//            //app.UseEndpoints(endpoints =>
//            //{
//            //    endpoints.MapControllers();
//            //});
//        }
//    }
//}


using CTV_MODULE_CMS_API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        // other configurations
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}
