using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace CleanArchitecture.Template.Host.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static void AddCustomHealthChecks(this IServiceCollection services)
        {
            services
                .AddHealthChecks();

            services
                .AddHealthChecksUI()
                .AddInMemoryStorage();
        }

        public static void UseHealthChecksEndpoints(this WebApplication app)
        {
            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            }).RequireAuthorization();

            app.MapHealthChecksUI(config =>
            {
                config.UIPath = "/health-ui";
                config.ApiPath = "/health-json";
            }).RequireAuthorization();
        }
    }
}
