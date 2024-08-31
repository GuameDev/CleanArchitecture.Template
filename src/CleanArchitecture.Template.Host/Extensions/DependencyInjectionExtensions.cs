using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace CleanArchitecture.Template.Host.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddCustomHealthChecks(this IServiceCollection services)
        {
            services.AddHealthChecks();

            services
            .AddHealthChecksUI()
            .AddInMemoryStorage();

        }

        public static void UseHealthChecksEndpoints(this WebApplication app)
        {

            // Add health check endpoints
            app.UseHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(config =>
            {
                config.UIPath = "/health-ui";
                config.ApiPath = "/health-json";
            });
        }
    }
}
