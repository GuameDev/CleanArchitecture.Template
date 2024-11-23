using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Users.Repositories;
using CleanArchitecture.Template.Application.Users.Services;
using CleanArchitecture.Template.Application.Users.Services.Authentication;
using CleanArchitecture.Template.Application.WeatherForecasts.Repositories;
using CleanArchitecture.Template.Infrastructure.Persistence;
using CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Base;
using CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Users;
using CleanArchitecture.Template.Infrastructure.Persistence.Repositories.WeatherForecasts;
using CleanArchitecture.Template.Infrastructure.Users.Services;
using CleanArchitecture.Template.Infrastructure.Users.Services.Authentication;
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

            //Persistence
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Users
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            //Authentication
            services.AddScoped<IUserPasswordHasher, RfcPasswordHasher>();
            services.AddScoped<IAuthTokenService, JwtService>();

            //WeatherForecast
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

            return services;
        }
    }
}
