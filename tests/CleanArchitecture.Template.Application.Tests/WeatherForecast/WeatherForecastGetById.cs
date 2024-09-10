using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.Services;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecast
{
    public class WeatherForecastGetByIdSpecs
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly WeatherForecastService _service;

        public WeatherForecastGetByIdSpecs()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _service = new WeatherForecastService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetById_ShouldReturnSuccess_WhenEntityExists()
        {
            // Arrange
            var request = new GetWeatherForecastByIdRequest(Guid.NewGuid());

            var entity = Domain.WeatherForecasts.WeatherForecast.Create(
                WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now)).Value,
                Temperature.FromCelsius(25).Value,
                Summary.Mild
            ).Value;

            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.GetByIdAsync(request)).ReturnsAsync(entity);

            _mockMapper.Setup(m => m.Map<GetWeatherForecastByIdResponse>(entity))
                      .Returns(new GetWeatherForecastByIdResponse()
                      {
                          Id = entity.Id,
                          Date = DateOnly.FromDateTime(DateTime.Now),
                          Summary = "Mild",
                          TemperatureCelsius = 25,
                          TemperatureFahrenheit = 77
                      }
                       );

            // Act
            var result = await _service.GetById(request);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(entity.Id, result.Value.Id);
        }

        [Fact]
        public async Task GetById_ShouldReturnFailure_WhenEntityDoesNotExist()
        {
            // Arrange
            var request = new GetWeatherForecastByIdRequest(Guid.NewGuid());

            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.GetByIdAsync(request)).ReturnsAsync((Domain.WeatherForecasts.WeatherForecast)null);

            // Act
            var result = await _service.GetById(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(WeatherForecastErrors.NotFound, result.Error);
        }
    }
}
