using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Update;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Update.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Repositories;
using CleanArchitecture.Template.Domain.WeatherForecasts;
using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.Temperatures;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecasts.Commands
{
    public class UpdateWeatherForecastSpecs : IClassFixture<MediatorIntegrationSetup>
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IWeatherForecastRepository> _mockWeatherForecastRepository;

        public UpdateWeatherForecastSpecs(MediatorIntegrationSetup fixture)
        {
            _mockUnitOfWork = fixture.CreateMockUnitOfWork();
            _mockMapper = fixture.CreateMockMapper();
            _mockWeatherForecastRepository = new Mock<IWeatherForecastRepository>();
        }

        [Fact]
        public async Task UpdateWeatherForecast_ShouldReturnSuccess_WhenRequestIsValid()
        {
            // Arrange
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

            _mockWeatherForecastRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                .ReturnsAsync(weatherForecast);

            _mockWeatherForecastRepository
                .Setup(repo => repo.Update(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()));

            _mockUnitOfWork
                .Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            _mockMapper
                .Setup(m => m.Map<UpdateWeatherForecastResponse>(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()))
                .Returns(new UpdateWeatherForecastResponse
                {
                    Id = request.Id,
                    Date = request.Date,
                    TemperatureCelsius = request.Temperature,
                    Summary = request.Summary.ToString()
                });

            var handler = new UpdateWeatherForecastHandler(
                _mockUnitOfWork.Object,
                _mockMapper.Object,
                _mockWeatherForecastRepository.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.NotNull(result.Value);
            Assert.Equal(request.Temperature, result.Value.TemperatureCelsius);
            Assert.Equal(request.Summary.ToString(), result.Value.Summary);

            _mockWeatherForecastRepository.Verify(repo => repo.Update(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task UpdateWeatherForecast_ShouldReturnFailure_WhenEntityIsNotFound()
        {
            // Arrange
            var request = new UpdateWeatherForecastCommand(
                Guid.NewGuid(),
                DateOnly.FromDateTime(DateTime.Now),
                30,
                TemperatureType.Celsius,
                Summary.Mild);

            _mockWeatherForecastRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                .ReturnsAsync((Domain.WeatherForecasts.WeatherForecast?)null);

            var handler = new UpdateWeatherForecastHandler(
                _mockUnitOfWork.Object,
                _mockMapper.Object,
                _mockWeatherForecastRepository.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(WeatherForecastErrors.NotFound, result.Error);

            _mockWeatherForecastRepository.Verify(repo => repo.Update(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Never);
            _mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }

        [Fact]
        public async Task UpdateWeatherForecast_ShouldReturnFailure_WhenTemperatureIsInvalid()
        {
            // Arrange
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

            _mockWeatherForecastRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                .ReturnsAsync(validWeatherForecast);

            var handler = new UpdateWeatherForecastHandler(
                _mockUnitOfWork.Object,
                _mockMapper.Object,
                _mockWeatherForecastRepository.Object);

            // Act
            var result = await handler.Handle(request, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(TemperatureErrors.UnderZeroCelsius, result.Error);

            _mockWeatherForecastRepository.Verify(repo => repo.Update(It.IsAny<Domain.WeatherForecasts.WeatherForecast>()), Times.Never);
            _mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
