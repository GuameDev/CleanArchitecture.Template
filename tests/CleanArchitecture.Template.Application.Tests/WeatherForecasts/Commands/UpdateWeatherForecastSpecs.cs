using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Update;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Update.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById.DTOs;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecasts.Commands
{
    public class UpdateWeatherForecastSpecs : IClassFixture<MediatorIntegrationSetup>
    {
        private readonly MediatorIntegrationSetup _fixture;

        public UpdateWeatherForecastSpecs(MediatorIntegrationSetup fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task UpdateWeatherForecast_ShouldReturnSuccess_WhenRequestIsValid()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockMapper = _fixture.CreateMockMapper();
            var mediator = _fixture.CreateMediator(mockUnitOfWork, mockMapper);

            var request = new UpdateWeatherForecastCommand(
                Guid.NewGuid(),
                DateOnly.FromDateTime(DateTime.Now),
                25, // Valid temperature
                TemperatureType.Celsius,
                Summary.Hot);

            var weatherForecast = Domain.WeatherForecasts.WeatherForecast.Create(
                request.Date,
                request.Temperature,
                request.TemperatureType,
                request.Summary).Value;

            // Ensure the repository returns a valid entity
            mockUnitOfWork.Setup(unitOfWork => unitOfWork.WeatherForecastRepository.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                          .ReturnsAsync(weatherForecast);

            // Mock the update behavior
            mockUnitOfWork.Setup(unitOfWork => unitOfWork.WeatherForecastRepository.Update(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()));
            mockUnitOfWork.Setup(unitOfWork => unitOfWork.CommitAsync(It.IsAny<CancellationToken>()))
                          .ReturnsAsync(1); // Return a successful commit

            mockMapper.Setup(m => m.Map<UpdateWeatherForecastResponse>(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()))
                      .Returns(new UpdateWeatherForecastResponse()
                      {
                          Id = request.Id,
                          Date = request.Date,
                          TemperatureCelsius = request.Temperature,
                          Summary = request.Summary.ToString()
                      });

            // Act
            var result = await mediator.Send(request);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(request.Temperature, result.Value.TemperatureCelsius);
            Assert.Equal(request.Summary.ToString(), result.Value.Summary);

            mockUnitOfWork.Verify(unitOfWork => unitOfWork.WeatherForecastRepository.Update(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Once);
            mockUnitOfWork.Verify(unitOfWork => unitOfWork.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }


        [Fact]
        public async Task UpdateWeatherForecast_ShouldReturnFailure_WhenEntityIsNotFound()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockMapper = _fixture.CreateMockMapper();
            var mediator = _fixture.CreateMediator(mockUnitOfWork, mockMapper);

            var request = new UpdateWeatherForecastCommand(
                Guid.NewGuid(),
                DateOnly.FromDateTime(DateTime.Now),
                30,
                TemperatureType.Celsius,
                Summary.Mild);

            // Setup repository to return null (not found)
            mockUnitOfWork.Setup(unitOfWork => unitOfWork.WeatherForecastRepository.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                          .ReturnsAsync((Domain.WeatherForecasts.WeatherForecast?)null);

            // Act
            var result = await mediator.Send(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(WeatherForecastErrors.NotFound, result.Error);

            mockUnitOfWork.Verify(unitOfWork => unitOfWork.WeatherForecastRepository.Update(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Never);
            mockUnitOfWork.Verify(unitOfWork => unitOfWork.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task UpdateWeatherForecast_ShouldReturnFailure_WhenTemperatureIsInvalid()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockMapper = _fixture.CreateMockMapper();
            var mediator = _fixture.CreateMediator(mockUnitOfWork, mockMapper);

            var request = new UpdateWeatherForecastCommand(
                Guid.NewGuid(),
                DateOnly.FromDateTime(DateTime.Now),
                -300, // Invalid temperature (below absolute zero)
                TemperatureType.Celsius,
                Summary.Mild);

            var validWeatherForecast = Domain.WeatherForecasts.WeatherForecast.Create(
                request.Date,
                25,
                TemperatureType.Celsius,
                request.Summary).Value;

            // Ensure the repository returns a valid entity
            mockUnitOfWork.Setup(unitOfWork => unitOfWork.WeatherForecastRepository.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                          .ReturnsAsync(validWeatherForecast);

            // Act
            var result = await mediator.Send(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(TemperatureErrors.UnderZeroCelsius, result.Error);

            mockUnitOfWork.Verify(unitOfWork => unitOfWork.WeatherForecastRepository.Update(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Never);
            mockUnitOfWork.Verify(unitOfWork => unitOfWork.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

    }
}
