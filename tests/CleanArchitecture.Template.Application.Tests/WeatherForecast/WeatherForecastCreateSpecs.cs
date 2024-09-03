using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Create;
using CleanArchitecture.Template.Application.WeatherForecast.Services;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Create;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using Moq;

namespace CleanArchitecture.Template.Application.Tests
{
    public class WeatherForecastCreateSpecs
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly WeatherForecastService _service;

        public WeatherForecastCreateSpecs()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _service = new WeatherForecastService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnSuccess_WhenValidRequest()
        {
            // Arrange
            var request = new WeatherForecastCreateRequest
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                Temperature = 25,
                TemperatureType = TemperatureType.Celsius,
                Summary = Summary.Mild
            };

            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()))
                           .Returns(Task.CompletedTask);

            _mockMapper.Setup(m => m.Map<CreateWeatherForecastResponse>(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()))
                       .Returns(new CreateWeatherForecastResponse()
                       {
                           Id = Guid.NewGuid(),
                           Date = DateOnly.FromDateTime(DateTime.Now),
                           Summary = "Mild",
                           TemperatureCelsius = 25,
                           TemperatureFahrenheit = 77
                       }
                       );

            // Act
            var result = await _service.CreateAsync(request);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnFailure_WhenInvalidTemperature()
        {
            // Arrange
            var request = new WeatherForecastCreateRequest
            {
                Date = DateOnly.FromDateTime(DateTime.Now),
                Temperature = -300, // Invalid temperature below absolute zero
                TemperatureType = TemperatureType.Celsius,
                Summary = Summary.Mild
            };

            // Act
            var result = await _service.CreateAsync(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(TemperatureErrors.UnderZeroCelsius, result.Error);
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnFailure_WhenInvalidDate()
        {
            // Arrange
            var request = new WeatherForecastCreateRequest
            {
                Date = DateOnly.FromDateTime(DateTime.MinValue),
                Temperature = 25,
                TemperatureType = TemperatureType.Celsius,
                Summary = Summary.Mild
            };

            // Act
            var result = await _service.CreateAsync(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(SharedKernel.CommonTypes.Enums.ErrorType.Validation, result.Error.Type);
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Never);
        }
    }
}
