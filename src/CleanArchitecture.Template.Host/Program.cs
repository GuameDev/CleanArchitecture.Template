
using CleanArchitecture.Template.Api.Extensions;
using CleanArchitecture.Template.Application;
using CleanArchitecture.Template.Host.Extensions;
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

            builder.Services.AddCustomHealthChecks();

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseSerilogRequestLogging(options => options.IncludeQueryInRequestPath = true);

            app.UseHealthChecksEndpoints();

            app.Configure();

            app.Run();
        }
    }
}
