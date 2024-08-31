using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Services;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Delete;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetById;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecast
{
    public class WeatherForecastDeleteSpecs
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly WeatherForecastService _service;

        public WeatherForecastDeleteSpecs()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();
            _service = new WeatherForecastService(_mockUnitOfWork.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnSuccess_WhenEntityIsDeleted()
        {
            //Arrange 
            var requestId = Guid.NewGuid();
            var request = new WeatherForecastDeleteRequest(requestId);
            var entity = Domain.WeatherForecasts.WeatherForecast.Create(
                WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now)),
                Temperature.FromCelsius(25),
                Domain.WeatherForecasts.Enums.Summary.Mild);

            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.GetByIdAsync(It.Is<WeatherForecastGetByIdRequest>(r => r.Id == requestId)))
                           .ReturnsAsync(entity.Value);

            //Act
            var result = await _service.DeleteAsync(request);

            //Assert
            Assert.True(result.IsSuccess);
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.DeleteAsync(It.IsAny<Guid>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.CommitAsync(It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
