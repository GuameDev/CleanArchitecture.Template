using CleanArchitecture.Template.Application.WeatherForecast;
using CleanArchitecture.Template.Application.WeatherForecast.Create;
using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects.Errors;
using Moq;

namespace CleanArchitecture.Template.Application.Tests
{
    public class WeatherForecastCreateSpecs
    {
        private readonly Mock<IWeatherForecastRepository> _mockRepository;
        private readonly WeatherForecastService _service;

        public WeatherForecastCreateSpecs()
        {
            _mockRepository = new Mock<IWeatherForecastRepository>();
            _service = new WeatherForecastService(_mockRepository.Object);
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

            _mockRepository.Setup(repo => repo.AddAsync(It.IsAny<Domain.Entities.WeatherForecast>())).Returns(Task.CompletedTask);

            // Act
            var result = await _service.CreateAsync(request);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Domain.Entities.WeatherForecast>()), Times.Once);
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
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Domain.Entities.WeatherForecast>()), Times.Never);
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnFailure_WhenInvalidDate()
        {
            // Arrange
            var request = new WeatherForecastCreateRequest
            {
                Date = DateOnly.FromDateTime(DateTime.MinValue), // Invalid date
                Temperature = 25,
                TemperatureType = TemperatureType.Celsius,
                Summary = Summary.Mild
            };

            // Act
            var result = await _service.CreateAsync(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(WeatherDateErrors.MinValue, result.Error);
            _mockRepository.Verify(repo => repo.AddAsync(It.IsAny<Domain.Entities.WeatherForecast>()), Times.Never);
        }
    }
}
