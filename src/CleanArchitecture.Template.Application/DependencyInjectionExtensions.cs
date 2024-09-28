using CleanArchitecture.Template.Application.Base.Behaviour;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Create;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitecture.Template.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Add MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly));

            // Add FluentValidation - Explicitly target the assembly containing the validators
            services.AddValidatorsFromAssemblyContaining<CreateWeatherForecastCommandValidator>(ServiceLifetime.Singleton);

            // Automapper setup
            services.AddAutoMapper(typeof(DependencyInjectionExtensions).Assembly);

            // Register ValidationBehavior for pipeline validation
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
