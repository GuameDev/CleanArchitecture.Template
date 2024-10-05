using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Delete;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;
namespace CleanArchitecture.Template.Application.Tests.WeatherForecasts.IntegrationTests
{
    public class DeleteWeatherForecastIntegrationSpecs
    {
        private readonly IMediator _mediator;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly ServiceProvider _serviceProvider;

        public DeleteWeatherForecastIntegrationSpecs()
        {
            var services = new ServiceCollection();

            // Register MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DeleteWeatherForecastHandler).Assembly));

            // Mocking external dependencies
            _mockUnitOfWork = new Mock<IUnitOfWork>();

            services.AddSingleton(_mockUnitOfWork.Object); // Use mocked UnitOfWork

            // Register Validators
            services.AddValidatorsFromAssemblyContaining<DeleteWeatherForecastCommand>();

            // Build the service provider
            _serviceProvider = services.BuildServiceProvider();

            // Get the mediator instance
            _mediator = _serviceProvider.GetRequiredService<IMediator>();
        }

        [Fact]
        public async Task DeleteWeatherForecast_ShouldReturnSuccess_WhenEntityIsDeleted()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var command = new DeleteWeatherForecastCommand(requestId);

            var weatherForecast = Domain.WeatherForecasts.WeatherForecast.Create(
                WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now)).Value,
                Temperature.FromCelsius(25).Value,
                Summary.Mild).Value;

            // Mock repository method to return the existing forecast
            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                           .ReturnsAsync(weatherForecast);

            // Mock delete and commit
            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.DeleteAsync(It.IsAny<Guid>()))
                           .Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>()))
                           .ReturnsAsync(1);

            // Act
            var result = await _mediator.Send(command);

            // Assert
            Assert.True(result.IsSuccess);
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.DeleteAsync(It.IsAny<Guid>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteWeatherForecast_ShouldReturnFailure_WhenEntityNotFound()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var command = new DeleteWeatherForecastCommand(requestId);

            // Mock repository method to return null, simulating entity not found
            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                           .ReturnsAsync((Domain.WeatherForecasts.WeatherForecast)null!);

            // Act
            var result = await _mediator.Send(command);

            // Assert
            Assert.False(result.IsSuccess);
            // Update the expected error code to match "WeatherForecast.NotFound"
            Assert.Equal(WeatherForecastErrors.NotFound.Code, result.Error.Code);
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.DeleteAsync(It.IsAny<Guid>()), Times.Never);
            _mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

    }
}