using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using MediatR;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecasts.Queries
{
    public class GetByIdWeatherForecastSpecs : IClassFixture<MediatorIntegrationSetup>
    {
        private readonly IMediator _mediator;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;

        public GetByIdWeatherForecastSpecs(MediatorIntegrationSetup fixture)
        {
            // Use the factory methods from the fixture to create fresh mocks for each test
            _mockUnitOfWork = fixture.CreateMockUnitOfWork();
            _mockMapper = fixture.CreateMockMapper();

            // Create a fresh mediator for each test using the mocks
            _mediator = fixture.CreateMediator(_mockUnitOfWork, _mockMapper);
        }

        [Fact]
        public async Task GetById_ShouldReturnSuccess_WhenEntityExists()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var query = new GetWeatherForecastByIdQuery(requestId);

            var entity = Domain.WeatherForecasts.WeatherForecast.Create(
                WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now)).Value,
                Temperature.FromCelsius(25).Value,
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
            _mockUnitOfWork.Setup(unitOfWork => unitOfWork.WeatherForecastRepository.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                           .ReturnsAsync(entity);

            _mockMapper.Setup(m => m.Map<GetWeatherForecastByIdResponse>(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()))
                       .Returns(mappedResponse);

            // Act
            var result = await _mediator.Send(query);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(entity.Id, result.Value.Id);
            Assert.Equal(mappedResponse.TemperatureCelsius, result.Value.TemperatureCelsius);
            _mockUnitOfWork.Verify(unitOfWork => unitOfWork.WeatherForecastRepository.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()), Times.Once);
        }

        [Fact]
        public async Task GetById_ShouldReturnFailure_WhenEntityDoesNotExist()
        {
            // Arrange
            var request = new GetWeatherForecastByIdQuery(Guid.NewGuid());

            _mockUnitOfWork.Setup(unitOfWork => unitOfWork.WeatherForecastRepository.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                           .ReturnsAsync((Domain.WeatherForecasts.WeatherForecast)null!);

            // Act
            var result = await _mediator.Send(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(WeatherForecastErrors.NotFound, result.Error);
        }
    }
}
