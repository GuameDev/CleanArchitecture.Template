
using CleanArchitecture.Template.Api.Extensions;
using CleanArchitecture.Template.Application;
using CleanArchitecture.Template.Infrastructure;

namespace CleanArchitecture.Template.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
              .AddApiServices()
              .AddApplicationServices()
              .AddInfrastructureServices();

            var app = builder.Build();

            app.UseStaticFiles();

            app.Configure();

            app.Run();
        }
    }
}
