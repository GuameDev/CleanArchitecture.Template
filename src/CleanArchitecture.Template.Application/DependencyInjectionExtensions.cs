using CleanArchitecture.Template.Application.Base.Behaviour;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create;
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

            // Add FluentValidation and ensure proper registration of validators
            services.AddValidatorsFromAssembly(typeof(CreateWeatherForecastCommandValidator).Assembly);

            // Automapper setup
            services.AddAutoMapper(typeof(DependencyInjectionExtensions).Assembly);

            // Register ValidationBehavior for pipeline validation
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
