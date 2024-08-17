using CleanArchitecture.Template.Application.WeatherForecast.Repository;
using CleanArchitecture.Template.Infrastructure.Persistence;
using CleanArchitecture.Template.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArchitecture.Template.Infrastructure
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                var configuration = sp.GetRequiredService<IConfiguration>();
                options.UseSqlServer(configuration.GetConnectionString("ApplicationDbContext"));

                //TODO: Add only in development
                options.EnableSensitiveDataLogging();

            });

            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();


            return services;
        }
    }
}
