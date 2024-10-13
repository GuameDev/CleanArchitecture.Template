using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetAll;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetAll.DTOs;
using MediatR;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecasts.Queries
{
    public class GetAllWeatherForecastHandlerSpecs : IClassFixture<MediatorIntegrationSetup>
    {
        private readonly IMediator _mediator;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public GetAllWeatherForecastHandlerSpecs(MediatorIntegrationSetup fixture)
        {
            // Set up the mock objects using the fixture's factory methods
            _mockUnitOfWork = fixture.CreateMockUnitOfWork();

            // Use the fixture to create a mediator with the mock objects
            _mediator = fixture.CreateMediator(_mockUnitOfWork, new Mock<IMapper>());
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

            _mockUnitOfWork.Setup(unitOfWork => unitOfWork.WeatherForecastRepository.GetAllAsync())
                           .ReturnsAsync(response);

            // Act
            var result = await _mediator.Send(query);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(2, result.Value.Elements.Count());
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.GetAllAsync(), Times.Once);
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

            _mockUnitOfWork.Setup(unitOfWork => unitOfWork.WeatherForecastRepository.GetAllAsync())
                           .ReturnsAsync(response);

            // Act
            var result = await _mediator.Send(query);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Empty(result.Value.Elements);
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.GetAllAsync(), Times.Once);
        }
    }
}
