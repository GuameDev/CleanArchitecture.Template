using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitecture.Template.Application
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            //Fluent Validation 
            services.AddValidatorsFromAssembly(typeof(DependencyInjectionExtensions).Assembly, includeInternalTypes: true);

            //Automapper
            services.AddAutoMapper(typeof(DependencyInjectionExtensions).Assembly);

            //MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjectionExtensions).Assembly));

            // Register the pipeline behavior for validation
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
