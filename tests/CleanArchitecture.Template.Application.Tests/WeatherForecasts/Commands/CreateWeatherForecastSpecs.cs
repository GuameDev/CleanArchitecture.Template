using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Repositories;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecasts.Commands
{
    public class CreateWeatherForecastSpecs : IClassFixture<MediatorIntegrationSetup>
    {
        private readonly MediatorIntegrationSetup _fixture;

        public CreateWeatherForecastSpecs(MediatorIntegrationSetup fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task CreateWeatherForecast_ShouldReturnSuccess_WhenRequestIsValid()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockMapper = _fixture.CreateMockMapper();
            var mockWeatherForecastRepository = new Mock<IWeatherForecastRepository>();

            var handler = new CreateWeatherForecastHandler(
                mockUnitOfWork.Object,
                mockMapper.Object,
                mockWeatherForecastRepository.Object
            );

            var request = new CreateWeatherForecastCommand(
                DateOnly.FromDateTime(DateTime.Now),
                25,
                TemperatureType.Celsius,
                Summary.Mild);

            var weatherForecast = Domain.WeatherForecasts.WeatherForecast.Create(
                request.Date,
                request.Temperature,
                request.TemperatureType,
                request.Summary).Value;

            var expectedResponse = new CreateWeatherForecastResponse
            {
                Id = Guid.NewGuid(),
                Date = request.Date,
                TemperatureCelsius = 25,
                TemperatureFahrenheit = 77,
                Summary = request.Summary.ToString()
            };

            // Mock repository and unit of work
            mockWeatherForecastRepository
                .Setup(repo => repo.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()))
                .Returns(Task.CompletedTask);

            mockUnitOfWork
                .Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            // Ensure mapper setup works with any instance of the weather forecast
            mockMapper
                .Setup(m => m.Map<CreateWeatherForecastResponse>(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()))
                .Returns(expectedResponse);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(expectedResponse.Id, result.Value.Id);
            Assert.Equal(expectedResponse.TemperatureCelsius, result.Value.TemperatureCelsius);
            Assert.Equal(expectedResponse.Summary, result.Value.Summary);

            // Verify interactions
            mockWeatherForecastRepository.Verify(repo => repo.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }


        [Fact]
        public async Task CreateWeatherForecast_ShouldReturnFailure_WhenTemperatureIsInvalid()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockMapper = _fixture.CreateMockMapper();
            var mockWeatherForecastRepository = new Mock<IWeatherForecastRepository>();

            var handler = new CreateWeatherForecastHandler(
                mockUnitOfWork.Object,
                mockMapper.Object,
                mockWeatherForecastRepository.Object
            );

            var request = new CreateWeatherForecastCommand(
                DateOnly.FromDateTime(DateTime.Now),
                -300, // Invalid temperature
                TemperatureType.Celsius,
                Summary.Mild);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(TemperatureErrors.UnderZeroCelsius, result.Error);

            // Verify no repository interactions occurred
            mockWeatherForecastRepository.Verify(repo => repo.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task CreateWeatherForecast_ShouldReturnFailure_WhenDateIsInvalid()
        {
            // Arrange
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockMapper = _fixture.CreateMockMapper();
            var mockWeatherForecastRepository = new Mock<IWeatherForecastRepository>();

            var handler = new CreateWeatherForecastHandler(
                mockUnitOfWork.Object,
                mockMapper.Object,
                mockWeatherForecastRepository.Object
            );

            var request = new CreateWeatherForecastCommand(
                DateOnly.FromDateTime(DateTime.MinValue), // Invalid date
                25,
                TemperatureType.Celsius,
                Summary.Mild);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorType.Validation, result.Error.Type);

            // Verify no repository interactions occurred
            mockWeatherForecastRepository.Verify(repo => repo.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Never);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
