
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.

builder.Services.AddControllers();
//Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



//namespace CTV_MODULE_CMS_API
//{
//    public class Program

//        /*
//            Thiết lập và khơi chạy ASP.NET
//            1. Tạo ra đối tượng Host(IHost):
//            - IServiceProvider
//            - Logging (ILogging)
//            - Configuration
//            - IHostedService(StartAsync) : Run HTTP Server (Kestrel Http)

//            2. Tạo ra IHostBuilder
//            3. Cấu hình
//            4. IHostBuilder.Build() => Host(IHost)
//            5. Host.Run();

//            Request => pineline(middleware): đường dẫn
//         */

//    {
//        public static void Main(string[] args)
//        {
//            IHostBuilder Builder = Host.CreateDefaultBuilder(args);

//            // Cấu hình mặc định cho HOST tạo ra
//            Builder.ConfigureWebHostDefaults((IWebHostBuilder WebBuilder) => {
//                WebBuilder.UseStartup<Startup>();  // ten cua class chua cac pineline
//            });

//            IHost host = Builder.Build();

//            host.Run();
//        }
//    }
//}