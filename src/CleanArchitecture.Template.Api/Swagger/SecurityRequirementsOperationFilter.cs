using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CleanArchitecture.Template.Api.Swagger
{
    public class JwtBearerOperationFilter : IOperationFilter
    {
        /// <summary>
        /// Applies the this filter on swagger documentation generation.
        /// </summary>
        /// <remarks>
        /// https://dotnetcoretutorials.com/2021/02/14/using-auth0-with-an-asp-net-core-api-part-3-swagger/
        /// </remarks>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation is null)
                throw new ArgumentNullException(nameof(operation));


            if (context is null)
                throw new ArgumentNullException(nameof(context));

            if (context.MethodInfo.DeclaringType is null)
                throw new ArgumentNullException(nameof(context.MethodInfo.DeclaringType));

            // then check if there is a method-level 'AllowAnonymous', as this overrides any controller-level 'Authorize'
            var anonControllerScope = context
                    .MethodInfo
                    .DeclaringType
                    .GetCustomAttributes(true)
                    .OfType<AllowAnonymousAttribute>();

            var anonMethodScope = context
                    .MethodInfo
                    .GetCustomAttributes(true)
                    .OfType<AllowAnonymousAttribute>();

            // only add authorization specification information if there is at least one 'Authorize' in the chain and NO method-level 'AllowAnonymous'
            if (!anonMethodScope.Any() && !anonControllerScope.Any())
            {
                // add generic message if the controller methods dont already specify the response type
                if (!operation.Responses.ContainsKey("401"))
                    operation.Responses.Add("401", new OpenApiResponse { Description = "If Authorization header not present, has no value or no valid jwt bearer token" });

                if (!operation.Responses.ContainsKey("403"))
                    operation.Responses.Add("403", new OpenApiResponse { Description = "If user not authorized to perform requested action" });

                var jwtAuthScheme = new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = JwtBearerDefaults.AuthenticationScheme }
                };

                operation.Security = new List<OpenApiSecurityRequirement>
                {
                    new OpenApiSecurityRequirement
                    {
                        [ jwtAuthScheme ] = new List<string>()
                    }
                };
            }
        }
    }
}
