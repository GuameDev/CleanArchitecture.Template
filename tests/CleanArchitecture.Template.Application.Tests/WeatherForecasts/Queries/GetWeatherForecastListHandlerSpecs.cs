using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.Get;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.Get.DTOs;
using CleanArchitecture.Template.Application.WeatherForecast.Specifications;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using MediatR;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecasts.Queries
{
    public class GetWeatherForecastListHandlerSpecs : IClassFixture<MediatorIntegrationSetup>
    {
        private readonly IMediator _mediator;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;

        public GetWeatherForecastListHandlerSpecs(MediatorIntegrationSetup fixture)
        {
            // Set up the mock objects using the fixture's factory methods
            _mockUnitOfWork = fixture.CreateMockUnitOfWork();

            // Use the fixture to create a mediator with the mock objects
            _mediator = fixture.CreateMediator(_mockUnitOfWork, new Mock<IMapper>());
        }

        [Fact]
        public async Task GetWeatherForecastList_ShouldReturnSuccess_WhenEntitiesExist()
        {
            // Arrange
            var query = new GetWeatherForecastListQuery
            {
                StartDate = DateTime.Now.AddDays(-5),
                EndDate = DateTime.Now.AddDays(5),
                Summary = Summary.Mild
            };

            var weatherForecasts = new List<GetWeatherForecastListItemResponse>
            {
                new GetWeatherForecastListItemResponse
                {
                    Id = Guid.NewGuid(),
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                    Summary = "Mild",
                    TemperatureCelsius = 20,
                    TemperatureFahrenheit = 68
                },
                new GetWeatherForecastListItemResponse
                {
                    Id = Guid.NewGuid(),
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                    Summary = "Mild",
                    TemperatureCelsius = 22,
                    TemperatureFahrenheit = 71.6
                }
            };

            var pagedResponse = new GetWeatherForecastListResponse
            {
                Elements = weatherForecasts,
                Page = 1,
                PageSize = 10,
                TotalCount = weatherForecasts.Count
            };

            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.GetListAsync(It.IsAny<WeatherForecastSpecification>()))
                           .ReturnsAsync(pagedResponse);

            // Act
            var result = await _mediator.Send(query);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(2, result.Value.Elements.Count());
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.GetListAsync(It.IsAny<WeatherForecastSpecification>()), Times.Once);
        }

        [Fact]
        public async Task GetWeatherForecastList_ShouldApplyPagination_WhenPaginationIsSpecified()
        {
            // Arrange
            var query = new GetWeatherForecastListQuery
            {
                IsPaginated = true,
                Page = 1,
                PageSize = 10
            };

            var weatherForecasts = new List<GetWeatherForecastListItemResponse>
            {
                new GetWeatherForecastListItemResponse
                {
                    Id = Guid.NewGuid(),
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)),
                    Summary = "Mild",
                    TemperatureCelsius = 20,
                    TemperatureFahrenheit = 68
                }
            };

            var pagedResponse = new GetWeatherForecastListResponse
            {
                Elements = weatherForecasts,
                Page = 1,
                PageSize = 10,
                TotalCount = weatherForecasts.Count
            };

            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.GetListAsync(It.IsAny<WeatherForecastSpecification>()))
                           .ReturnsAsync(pagedResponse);

            // Act
            var result = await _mediator.Send(query);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Single(result.Value.Elements); // We expect 1 result in the paginated list
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.GetListAsync(It.IsAny<WeatherForecastSpecification>()), Times.Once);
        }

        [Fact]
        public async Task GetWeatherForecastList_ShouldReturnEmptyList_WhenNoEntitiesExist()
        {
            // Arrange
            var query = new GetWeatherForecastListQuery
            {
                StartDate = DateTime.Now.AddDays(-10),
                EndDate = DateTime.Now.AddDays(-5) // No data in this range
            };

            var pagedResponse = new GetWeatherForecastListResponse
            {
                Elements = new List<GetWeatherForecastListItemResponse>(),
                Page = 1,
                PageSize = 10,
                TotalCount = 0
            };

            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.GetListAsync(It.IsAny<WeatherForecastSpecification>()))
                           .ReturnsAsync(pagedResponse);

            // Act
            var result = await _mediator.Send(query);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Empty(result.Value.Elements);
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.GetListAsync(It.IsAny<WeatherForecastSpecification>()), Times.Once);
        }
    }
}
