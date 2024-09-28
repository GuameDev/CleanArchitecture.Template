
using CleanArchitecture.Template.Api.Extensions;
using CleanArchitecture.Template.Application;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Create;
using CleanArchitecture.Template.Host.Extensions;
using CleanArchitecture.Template.Infrastructure;
using FluentValidation;
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

            // Example of logging registered services for debugging
            var serviceProvider = builder.Services.BuildServiceProvider();

            // Example to check if the validator is registered
            var validator = serviceProvider.GetService<IValidator<CreateWeatherForecastCommand>>();
            if (validator == null)
            {
                Console.WriteLine("Validator not registered for YourCommandHere.");
            }
            else
            {
                Console.WriteLine("Validator registered successfully.");
            }
            var assembly = typeof(CreateWeatherForecastCommandValidator).Assembly;
            var validators = serviceProvider.GetServices<IValidator>();
            // If you want to see all services registered, log all services
            foreach (var service in validators)
            {
                Console.WriteLine($"Registered service: {service.GetType()}");
            }

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseSerilogRequestLogging(options => options.IncludeQueryInRequestPath = true);

            app.UseHealthChecksEndpoints();

            app.Configure();

            app.Run();
        }
    }
}
