using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.Tests.Base;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Delete;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using MediatR;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecasts.Commands
{
    public class DeleteWeatherForecastHandlerSpecs : IClassFixture<MediatorIntegrationSetup>
    {
        private readonly IMediator _mediator;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;

        public DeleteWeatherForecastHandlerSpecs(MediatorIntegrationSetup fixture)
        {
            // Use the factory methods from the fixture to create fresh mocks for each test
            _mockUnitOfWork = fixture.CreateMockUnitOfWork();
            _mockMapper = fixture.CreateMockMapper();

            // Create a fresh mediator for each test using the mocks
            _mediator = fixture.CreateMediator(_mockUnitOfWork, _mockMapper);
        }

        [Fact]
        public async Task DeleteWeatherForecast_ShouldReturnSuccess_WhenEntityIsDeleted()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var command = new DeleteWeatherForecastCommand(requestId);

            var weatherForecast = Domain.WeatherForecasts.WeatherForecast.Create(
                WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now)).Value,
                Temperature.FromCelsius(25).Value,
                Summary.Mild).Value;

            // Mock repository method to return the existing forecast
            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                           .ReturnsAsync(weatherForecast);

            // Mock delete and commit
            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.DeleteAsync(It.IsAny<Guid>()))
                           .Returns(Task.CompletedTask);
            _mockUnitOfWork.Setup(uow => uow.CommitAsync(It.IsAny<CancellationToken>()))
                           .ReturnsAsync(1);

            // Act
            var result = await _mediator.Send(command);

            // Assert
            Assert.True(result.IsSuccess);
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.DeleteAsync(It.IsAny<Guid>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task DeleteWeatherForecast_ShouldReturnFailure_WhenEntityNotFound()
        {
            // Arrange
            var requestId = Guid.NewGuid();
            var command = new DeleteWeatherForecastCommand(requestId);

            // Mock repository method to return null, simulating entity not found
            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                           .ReturnsAsync((Domain.WeatherForecasts.WeatherForecast)null!);

            // Act
            var result = await _mediator.Send(command);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(WeatherForecastErrors.NotFound.Code, result.Error.Code);
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.DeleteAsync(It.IsAny<Guid>()), Times.Never);
            _mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Never);
        }
    }
}
