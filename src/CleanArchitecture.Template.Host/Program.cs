
using CleanArchitecture.Template.Api.Extensions;
using CleanArchitecture.Template.Application;
using CleanArchitecture.Template.Infrastructure;
using Serilog;

namespace CleanArchitecture.Template.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));

            builder.Services
                      .AddApiServices()
                      .AddApplicationServices()
                      .AddInfrastructureServices();

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseSerilogRequestLogging(options => options.IncludeQueryInRequestPath = true);

            app.Configure();

            app.Run();
        }
    }
}
