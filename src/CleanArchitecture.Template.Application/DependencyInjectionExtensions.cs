using CleanArchitecture.Template.Application.WeatherForecast;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Template.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastService, WeatherForecastService>();

            return services;
        }
    }
}
