using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Repository;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecasts.Queries
{
    public class GetByIdWeatherForecastSpecs : IClassFixture<MediatorIntegrationSetup>
    {
        private readonly Mock<IWeatherForecastRepository> _mockWeatherForecastRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;

        public GetByIdWeatherForecastSpecs(MediatorIntegrationSetup fixture)
        {
            _mockWeatherForecastRepository = new Mock<IWeatherForecastRepository>();
            _mockUnitOfWork = fixture.CreateMockUnitOfWork();
            _mockMapper = fixture.CreateMockMapper();
        }

        [Fact]
        public async Task GetById_ShouldReturnSuccess_WhenEntityExists()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var query = new GetWeatherForecastByIdQuery(requestId);

            var entity = Domain.WeatherForecasts.WeatherForecast.Create(
                DateOnly.FromDateTime(DateTime.Now),
                25,
                TemperatureType.Celsius,
                Summary.Mild).Value;

            var mappedResponse = new GetWeatherForecastByIdResponse
            {
                Id = entity.Id,
                Date = entity.Date.Value,
                Summary = entity.Summary.ToString(),
                TemperatureCelsius = entity.Temperature.ToCelsius(),
                TemperatureFahrenheit = entity.Temperature.ToFahrenheit()
            };

            // Mock repository and mapper
            _mockWeatherForecastRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                .ReturnsAsync(entity);

            _mockMapper
                .Setup(m => m.Map<GetWeatherForecastByIdResponse>(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()))
                .Returns(mappedResponse);

            var handler = new GetWeatherForecastByIdHandler(
                _mockUnitOfWork.Object,
                _mockMapper.Object,
                _mockWeatherForecastRepository.Object);

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(entity.Id, result.Value.Id);
            Assert.Equal(mappedResponse.TemperatureCelsius, result.Value.TemperatureCelsius);
            _mockWeatherForecastRepository.Verify(repo => repo.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()), Times.Once);
        }

        [Fact]
        public async Task GetById_ShouldReturnFailure_WhenEntityDoesNotExist()
        {
            // Arrange
            var request = new GetWeatherForecastByIdQuery(Guid.NewGuid());

            _mockWeatherForecastRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                .ReturnsAsync((Domain.WeatherForecasts.WeatherForecast?)null);

            var handler = new GetWeatherForecastByIdHandler(
                _mockUnitOfWork.Object,
                _mockMapper.Object,
                _mockWeatherForecastRepository.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(WeatherForecastErrors.NotFound, result.Error);
        }
    }
}
