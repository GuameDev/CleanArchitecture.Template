using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.User.Services;
using CleanArchitecture.Template.Application.WeatherForecast.Repository;
using CleanArchitecture.Template.Infrastructure.Persistence;
using CleanArchitecture.Template.Infrastructure.Persistence.Repositories;
using CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Base;
using CleanArchitecture.Template.Infrastructure.Services.Security;
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

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

            services.AddScoped<IUserPasswordHasher, RfcPasswordHasher>();

            return services;
        }
    }
}
