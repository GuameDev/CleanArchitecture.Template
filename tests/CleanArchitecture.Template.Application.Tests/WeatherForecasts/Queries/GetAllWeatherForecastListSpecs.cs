using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetAll;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetAll.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Repository;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecasts.Queries
{
    public class GetAllWeatherForecastHandlerSpecs : IClassFixture<MediatorIntegrationSetup>
    {
        private readonly Mock<IWeatherForecastRepository> _mockWeatherForecastRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public GetAllWeatherForecastHandlerSpecs(MediatorIntegrationSetup fixture)
        {
            _mockWeatherForecastRepository = new Mock<IWeatherForecastRepository>();
            _mockUnitOfWork = fixture.CreateMockUnitOfWork();
        }

        [Fact]
        public async Task GetAllWeatherForecast_ShouldReturnSuccess_WhenEntitiesExist()
        {
            // Arrange
            var query = new GetAllWeatherForecastQuery();

            var weatherForecasts = new List<GetAllWeatherForecastListItemResponse>
            {
                new GetAllWeatherForecastListItemResponse
                {
                    Id = Guid.NewGuid(),
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                    Summary = "Mild",
                    TemperatureCelsius = 20,
                    TemperatureFahrenheit = 68
                },
                new GetAllWeatherForecastListItemResponse
                {
                    Id = Guid.NewGuid(),
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                    Summary = "Mild",
                    TemperatureCelsius = 22,
                    TemperatureFahrenheit = 71.6
                }
            };

            var response = new GetAllWeatherForecastResponse
            {
                Elements = weatherForecasts
            };

            _mockWeatherForecastRepository
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(response);

            var handler = new GetAllWeatherForecastHandler(
                _mockUnitOfWork.Object,
                _mockWeatherForecastRepository.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(2, result.Value.Elements.Count());
            _mockWeatherForecastRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async Task GetAllWeatherForecast_ShouldReturnEmptyList_WhenNoEntitiesExist()
        {
            // Arrange
            var query = new GetAllWeatherForecastQuery();

            var response = new GetAllWeatherForecastResponse
            {
                Elements = new List<GetAllWeatherForecastListItemResponse>()
            };

            _mockWeatherForecastRepository
                .Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(response);

            var handler = new GetAllWeatherForecastHandler(
                _mockUnitOfWork.Object,
                _mockWeatherForecastRepository.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Empty(result.Value.Elements);
            _mockWeatherForecastRepository.Verify(repo => repo.GetAllAsync(), Times.Once);
        }
    }
}
