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
            // Use Authorization Middleware before mapping health check endpoints
            app.UseWhen(context => context.Request.Path.StartsWithSegments("/health"), appBuilder =>
            {
                appBuilder.UseAuthentication();
                appBuilder.UseAuthorization();
            });

            app.UseWhen(context => context.Request.Path.StartsWithSegments("/health-ui"), appBuilder =>
            {
                appBuilder.UseAuthentication();
                appBuilder.UseAuthorization();
            });

            app.MapHealthChecks("/health", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.MapHealthChecksUI(config =>
            {
                config.UIPath = "/health-ui";
                config.ApiPath = "/health-json";
            });
        }

    }
}
