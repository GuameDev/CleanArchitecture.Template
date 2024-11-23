using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Delete;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Repository;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecasts.Commands
{
    public class DeleteWeatherForecastSpecs : IClassFixture<MediatorIntegrationSetup>
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IWeatherForecastRepository> _mockWeatherForecastRepository;

        public DeleteWeatherForecastSpecs(MediatorIntegrationSetup fixture)
        {
            _mockUnitOfWork = fixture.CreateMockUnitOfWork();
            _mockWeatherForecastRepository = new Mock<IWeatherForecastRepository>();
        }

        [Fact]
        public async Task DeleteWeatherForecast_ShouldReturnSuccess_WhenEntityIsDeleted()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var command = new DeleteWeatherForecastCommand(requestId);

            var weatherForecast = Domain.WeatherForecasts.WeatherForecast.Create(
                DateOnly.FromDateTime(DateTime.Now),
                25,
                TemperatureType.Celsius,
                Summary.Mild).Value;

            // Mock repository method to return the existing forecast
            _mockWeatherForecastRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                .ReturnsAsync(weatherForecast);

            // Mock delete and commit
            _mockWeatherForecastRepository
                .Setup(repo => repo.DeleteAsync(It.IsAny<Guid>()))
                .Returns(Task.CompletedTask);

            _mockUnitOfWork
                .Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);

            var handler = new DeleteWeatherForecastHandler(
                _mockUnitOfWork.Object,
                _mockWeatherForecastRepository.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.True(result.IsSuccess);
            _mockWeatherForecastRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Guid>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteWeatherForecast_ShouldReturnFailure_WhenEntityNotFound()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var command = new DeleteWeatherForecastCommand(requestId);

            // Mock repository method to return null, simulating entity not found
            _mockWeatherForecastRepository
                .Setup(repo => repo.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                .ReturnsAsync((Domain.WeatherForecasts.WeatherForecast)null!);

            var handler = new DeleteWeatherForecastHandler(
                _mockUnitOfWork.Object,
                _mockWeatherForecastRepository.Object);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(WeatherForecastErrors.NotFound.Code, result.Error.Code);
            _mockWeatherForecastRepository.Verify(repo => repo.DeleteAsync(It.IsAny<Guid>()), Times.Never);
            _mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
