using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;


namespace CleanArchitecture.Template.Api.Swagger
{
    internal static class SwaggerGenHelpers
    {
        internal static void Configure(SwaggerGenOptions options)
        {
            // Path to XML comments file for the API project
            var apiXmlPath = Path.Combine(AppContext.BaseDirectory, "CleanArchitecture.Template.Api.xml");
            if (File.Exists(apiXmlPath))
                options.IncludeXmlComments(apiXmlPath);

            // Path to XML comments file for the Application project
            var applicationXmlPath = Path.Combine(AppContext.BaseDirectory, "CleanArchitecture.Template.Application.xml");
            if (File.Exists(applicationXmlPath))
                options.IncludeXmlComments(applicationXmlPath);

            options.MapType<TimeOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "time",
                Example = new OpenApiString("09:30:05")
            });
            options.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date",
                Example = new OpenApiString("2023-12-31")
            });

            options.SupportNonNullableReferenceTypes();
            options.UseInlineDefinitionsForEnums();

            options.DocumentFilter<HealthChecksDocumentFilter>();
            options.SchemaFilter<FluentValidationSchemaFilter>();

            // Define JWT security schema
            OpenApiSecurityScheme securityScheme = new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                Reference = new OpenApiReference()
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            };

            options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, securityScheme);
            options.OperationFilter<JwtBearerOperationFilter>();

            options.DocumentFilter<OrderByHttpVerbFilter>();
        }


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
}