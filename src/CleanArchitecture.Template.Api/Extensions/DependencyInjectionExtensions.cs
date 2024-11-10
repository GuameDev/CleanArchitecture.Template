using CleanArchitecture.Template.Api.Filters;
using CleanArchitecture.Template.Api.Swagger;
using CleanArchitecture.Template.SharedKernel.Options.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace CleanArchitecture.Template.Api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers(options =>
            {
                options.Filters.Add<LoggingActionFilter>();
                options.Filters.Add<ProblemDetailsExceptionFilter>();
            })
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

                //This ensures that validation is only handled via your MediatR pipeline.
                options.SuppressModelStateInvalidFilter = true;
            }).AddApplicationPart(typeof(DependencyInjectionExtensions).Assembly);

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            services.AddProblemDetails();

            services.AddSwaggerGen(SwaggerGenHelpers.Configure);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                //TODO: find an approach to ensure the options pattern dtos always has data in any environment.
                JwtSettings jwtSettings = configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>()!;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.AccessToken.Issuer,
                    ValidAudience = jwtSettings.AccessToken.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.AccessToken.Key))
                };
            });
            services.AddAuthorization();
            services.AddHttpContextAccessor();

            services.AddEndpointsApiExplorer();

            return services;
        }
    }
}
