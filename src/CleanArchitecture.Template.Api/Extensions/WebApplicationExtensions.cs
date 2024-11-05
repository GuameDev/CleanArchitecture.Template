using CleanArchitecture.Template.Api.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace CleanArchitecture.Template.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void Configure(this WebApplication app)
        {
            if (!app.Environment.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Exception handling
            app.UseExceptionHandler();

            // Request and response logging middleware
            app.UseMiddleware<RequestResponseLoggingMiddleware>();

            // Custom exception handling middleware
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            // Authentication and Active User Middleware
            app.UseHttpsRedirection();
            app.UseAuthentication();

            // Ensure ActiveUserMiddleware has access to authenticated context
            app.UseMiddleware<ActiveUserMiddleware>();

            // Authorization
            app.UseAuthorization();

            // Map controllers with authorization requirement
            app.MapControllers().RequireAuthorization();
        }

    }
}
