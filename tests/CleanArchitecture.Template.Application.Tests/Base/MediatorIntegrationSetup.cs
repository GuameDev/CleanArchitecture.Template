using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetAll;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.Base
{
    public class MediatorIntegrationSetup
    {
        // Create a mock of IUnitOfWork
        public Mock<IUnitOfWork> CreateMockUnitOfWork()
        {
            return new Mock<IUnitOfWork>();
        }

        // Create a mock of IMapper (if necessary for mapping operations)
        public Mock<IMapper> CreateMockMapper()
        {
            return new Mock<IMapper>();
        }

        // This method sets up the Mediator with mock services and registers handlers
        public IMediator CreateMediator(Mock<IUnitOfWork> mockUnitOfWork, Mock<IMapper> mockMapper = null!)
        {
            // Ensure that required dependencies are not null
            if (mockUnitOfWork == null) throw new ArgumentNullException(nameof(mockUnitOfWork));

            // Create a ServiceProvider with required services for Mediator and handlers
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IMediator, Mediator>() // Add the Mediator itself
                .AddTransient<Func<Type, object>>(sp => sp.GetService!) // ServiceFactory delegate to resolve handlers
                .AddSingleton(mockUnitOfWork.Object) // Register mock UnitOfWork
                .AddSingleton(mockMapper?.Object ?? Mock.Of<IMapper>()) // If mockMapper is null, use a default mock
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetAllWeatherForecastHandler>()) // Add handlers from the same assembly
                .BuildServiceProvider();

            // Resolve and return the Mediator
            return serviceProvider.GetRequiredService<IMediator>();
        }
    }
}