using CleanArchitecture.Template.SharedKernel.Options.Security;

namespace CleanArchitecture.Template.Host.Extensions
{
    public static class OptionsExtensions
    {

        public static IServiceCollection AddSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

            return services;
        }
    }
}
