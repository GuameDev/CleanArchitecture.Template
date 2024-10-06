using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.Base
{
    public class MediatorIntegrationSetup
    {
        public ServiceProvider ServiceProvider { get; private set; }

        // Factory method to create a new service provider and mediator
        public IMediator CreateMediator(Mock<IUnitOfWork> mockUnitOfWork, Mock<IMapper> mockMapper)
        {
            var services = new ServiceCollection();

            // Register MediatR and other dependencies
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetWeatherForecastByIdHandler).Assembly));

            services.AddSingleton(mockUnitOfWork.Object); // Inject fresh mocks
            services.AddSingleton(mockMapper.Object);     // Inject fresh mocks

            // Register Validators (if any)
            services.AddValidatorsFromAssemblyContaining<GetWeatherForecastByIdQuery>();

            ServiceProvider = services.BuildServiceProvider();
            return ServiceProvider.GetRequiredService<IMediator>();
        }

        // Factory method to create new mocks for each test
        public Mock<IUnitOfWork> CreateMockUnitOfWork() => new Mock<IUnitOfWork>();

        public Mock<IMapper> CreateMockMapper() => new Mock<IMapper>();

        // Clean up resources if necessary
        public void Dispose()
        {
            if (ServiceProvider is IDisposable disposable)
            {
                disposable.Dispose();
            }
        }
    }
}