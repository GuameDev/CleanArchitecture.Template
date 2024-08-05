using CleanArchitecture.Template.Api.Swagger;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Template.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {

            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .ConfigureApiBehaviorOptions(options =>
                {
                    // https://learn.microsoft.com/es-es/dotnet/core/compatibility/aspnet-core/7.0/api-controller-action-parameters-di
                    options.DisableImplicitFromServicesParameters = true;
                });

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.AddProblemDetails();

            services.AddSwaggerGen(SwaggerGenHelpers.Configure);

            services.AddAuthentication().AddJwtBearer();
            services.AddAuthorization();
            services.AddHttpContextAccessor();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();


            return services;
        }
    }
}
