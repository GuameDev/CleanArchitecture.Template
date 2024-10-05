using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Create;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Create.DTOs;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecasts.IntegrationTests
{
    public class CreateWeatherForecastIntegrationSpecs
    {
        private readonly IMediator _mediator;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ServiceProvider _serviceProvider;

        public CreateWeatherForecastIntegrationSpecs()
        {
            var services = new ServiceCollection();

            // Register MediatR with new configuration
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateWeatherForecastHandler).Assembly));

            // Mocking external dependencies
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();

            services.AddSingleton(_mockUnitOfWork.Object); // Use the mocked UnitOfWork
            services.AddSingleton(_mockMapper.Object);     // Use the mocked Mapper

            // Register Validators
            services.AddValidatorsFromAssemblyContaining<CreateWeatherForecastCommand>();

            // Build the service provider
            _serviceProvider = services.BuildServiceProvider();

            // Get the mediator instance from service provider
            _mediator = _serviceProvider.GetRequiredService<IMediator>();
        }

        [Fact]
        public async Task CreateWeatherForecast_ShouldReturnSuccess_WhenRequestIsValid()
        {
            // Arrange
            var request = new CreateWeatherForecastCommand(
                DateOnly.FromDateTime(DateTime.Now),
                25,
                TemperatureType.Celsius,
                Summary.Mild);

            var weatherForecast = Domain.WeatherForecasts.WeatherForecast.Create(
                WeatherDate.Create(request.Date).Value,
                Temperature.Create(request.Temperature, request.TemperatureType).Value,
                request.Summary).Value;

            // Mock the unit of work to return a successful response when saving the forecast
            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()))
                           .Returns(Task.CompletedTask);

            // Correct the return type of CommitAsync to return Task<int>
            _mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>()))
                           .ReturnsAsync(1); // Return an integer to fix the mismatch

            _mockMapper.Setup(m => m.Map<CreateWeatherForecastResponse>(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()))
                       .Returns(new CreateWeatherForecastResponse()
                       {
                           Id = Guid.NewGuid(),
                           Date = request.Date,
                           TemperatureCelsius = 25,
                           TemperatureFahrenheit = 77,
                           Summary = request.Summary.ToString()
                       });

            // Act
            var result = await _mediator.Send(request);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CreateWeatherForecast_ShouldReturnFailure_WhenTemperatureIsInvalid()
        {
            // Arrange
            var request = new CreateWeatherForecastCommand(
                DateOnly.FromDateTime(DateTime.Now),
                -300, // Invalid temperature (below absolute zero)
                TemperatureType.Celsius,
                Summary.Mild);

            // Act
            var result = await _mediator.Send(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(TemperatureErrors.UnderZeroCelsius, result.Error);
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Never);
        }

        [Fact]
        public async Task CreateWeatherForecast_ShouldReturnFailure_WhenDateIsInvalid()
        {
            // Arrange
            var request = new CreateWeatherForecastCommand(
                DateOnly.FromDateTime(DateTime.MinValue), // Invalid date
                25,
                TemperatureType.Celsius,
                Summary.Mild);

            // Act
            var result = await _mediator.Send(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorType.Validation, result.Error.Type);
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Never);
        }
    }
}