using CleanArchitecture.Template.Application.WeatherForecast.Repository;
using CleanArchitecture.Template.Application.WeatherForecast.Services;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetById;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using Moq;

namespace CleanArchitecture.Template.Application.Tests
{
    public class WeatherForecastGetByIdSpecs
    {
        private readonly Mock<IWeatherForecastRepository> _mockRepository;
        private readonly WeatherForecastService _service;

        public WeatherForecastGetByIdSpecs()
        {
            _mockRepository = new Mock<IWeatherForecastRepository>();
            _service = new WeatherForecastService(_mockRepository.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnSuccess_WhenEntityExists()
        {
            // Arrange
            var request = new WeatherForecastGetByIdRequest(Guid.NewGuid());

            var weatherForecast = Domain.WeatherForecasts.WeatherForecast.Create(
                WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now)).Value,
                Temperature.FromCelsius(25).Value,
                Summary.Mild
            ).Value;

            _mockRepository.Setup(repo => repo.GetByIdAsync(request)).ReturnsAsync(weatherForecast);

            // Act
            var result = await _service.GetById(request);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(weatherForecast.Id, result.Value.Id);
        }

        [Fact]
        public async Task GetById_ShouldReturnFailure_WhenEntityDoesNotExist()
        {
            // Arrange
            var request = new WeatherForecastGetByIdRequest(Guid.NewGuid());

            _mockRepository.Setup(repo => repo.GetByIdAsync(request)).ReturnsAsync((Domain.WeatherForecasts.WeatherForecast)null);

            // Act
            var result = await _service.GetById(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(WeatherForecastErrors.NotFound, result.Error);
        }
    }
}