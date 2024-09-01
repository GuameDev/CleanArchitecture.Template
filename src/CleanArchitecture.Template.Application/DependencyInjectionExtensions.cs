using CleanArchitecture.Template.Application.WeatherForecast.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitecture.Template.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            //Fluent Validation 
            services.AddValidatorsFromAssembly(typeof(DependencyInjectionExtensions).Assembly);
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();

            //Automapper
            services.AddAutoMapper(typeof(DependencyInjectionExtensions).Assembly);

            //MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly));

            return services;
        }
    }
}
