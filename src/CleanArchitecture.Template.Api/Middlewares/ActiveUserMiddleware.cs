using CleanArchitecture.Template.Application.Users.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CleanArchitecture.Template.Api.Middlewares
{
    public class ActiveUserMiddleware
    {
        private readonly RequestDelegate _next;

        public ActiveUserMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ICurrentUserService currentUserService)
        {
            // If user is not authenticated, proceed to next middleware
            if (!currentUserService.IsAuthenticated)
            {
                await _next(context);
                return;
            }

            // Retrieve current user and check activation status
            var user = await currentUserService.GetCurrentUserAsync();

            // If user is inactive, return 403 Forbidden status and short-circuit pipeline
            if (user is not null && !user.IsActive)
            {
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status403Forbidden,
                    Title = "User account is inactive",
                    Detail = "Your account has been deactivated. Please contact support for further assistance."
                };

                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                return;
            }


            await _next(context);
        }
    }
}
