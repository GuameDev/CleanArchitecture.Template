using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create.DTOs;
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
            // Arrange - Create fresh mocks using factory methods from the fixture
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockMapper = _fixture.CreateMockMapper();
            var mediator = _fixture.CreateMediator(mockUnitOfWork, mockMapper);

            var request = new CreateWeatherForecastCommand(
                DateOnly.FromDateTime(DateTime.Now),
                25,
                TemperatureType.Celsius,
                Summary.Mild);

            var weatherForecast = Domain.WeatherForecasts.WeatherForecast.Create(
                request.Date,
                request.Temperature, request.TemperatureType,
                request.Summary).Value;

            // Mock the unit of work to return a successful response when saving the forecast
            mockUnitOfWork.Setup(unitOfWork => unitOfWork.WeatherForecastRepository.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()))
                           .Returns(Task.CompletedTask);

            // Correct the return type of CommitAsync to return Task<int>
            mockUnitOfWork.Setup(unitOfWork => unitOfWork.CommitAsync(It.IsAny<CancellationToken>()))
                           .ReturnsAsync(1); // Return an integer to fix the mismatch

            mockMapper.Setup(m => m.Map<CreateWeatherForecastResponse>(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()))
                       .Returns(new CreateWeatherForecastResponse()
                       {
                           Id = Guid.NewGuid(),
                           Date = request.Date,
                           TemperatureCelsius = 25,
                           TemperatureFahrenheit = 77,
                           Summary = request.Summary.ToString()
                       });

            // Act
            var result = await mediator.Send(request);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Once);
            mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task CreateWeatherForecast_ShouldReturnFailure_WhenTemperatureIsInvalid()
        {
            // Arrange - Create fresh mocks
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockMapper = _fixture.CreateMockMapper();
            var mediator = _fixture.CreateMediator(mockUnitOfWork, mockMapper);

            var request = new CreateWeatherForecastCommand(
                DateOnly.FromDateTime(DateTime.Now),
                -300, // Invalid temperature (below absolute zero)
                TemperatureType.Celsius,
                Summary.Mild);

            // Act
            var result = await mediator.Send(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(TemperatureErrors.UnderZeroCelsius, result.Error);
            mockUnitOfWork.Verify(unitOfWork => unitOfWork.WeatherForecastRepository.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Never);
        }

        [Fact]
        public async Task CreateWeatherForecast_ShouldReturnFailure_WhenDateIsInvalid()
        {
            // Arrange - Create fresh mocks
            var mockUnitOfWork = _fixture.CreateMockUnitOfWork();
            var mockMapper = _fixture.CreateMockMapper();
            var mediator = _fixture.CreateMediator(mockUnitOfWork, mockMapper);

            var request = new CreateWeatherForecastCommand(
                DateOnly.FromDateTime(DateTime.MinValue), // Invalid date
                25,
                TemperatureType.Celsius,
                Summary.Mild);

            // Act
            var result = await mediator.Send(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(ErrorType.Validation, result.Error.Type);
            mockUnitOfWork.Verify(unitOfWork => unitOfWork.WeatherForecastRepository.AddAsync(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Never);
        }
    }
}