using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace CleanArchitecture.Template.Api.Swagger
{
    public class HealthChecksDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var pathItem = new OpenApiPathItem();
            pathItem.AddOperation(OperationType.Get, new OpenApiOperation
            {
                Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Health Checks" } },
                Summary = "Health Check Endpoint",
                Description = "Returns the health status of the application.",
                Responses = new OpenApiResponses
            {
                {
                    "200", new OpenApiResponse
                    {
                        Description = "OK"
                    }
                },
                {
                    "503", new OpenApiResponse
                    {
                        Description = "Service Unavailable"
                    }
                }
            }
            });

            swaggerDoc.Paths.Add("/health", pathItem);
        }
    }
}
