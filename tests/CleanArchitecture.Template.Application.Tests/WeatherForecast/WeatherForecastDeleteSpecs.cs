using CleanArchitecture.Template.Application.WeatherForecast.Repository;
using CleanArchitecture.Template.Application.WeatherForecast.Services;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Delete;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetById;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecast
{
    public class WeatherForecastDeleteSpecs
    {
        private readonly Mock<IWeatherForecastRepository> _mockRepository;

        public WeatherForecastDeleteSpecs()
        {
            _mockRepository = new Mock<IWeatherForecastRepository>();
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnSuccess_WhenEntityIsDeleted()
        {
            //Arrange 
            var repositoryMock = new Mock<IWeatherForecastRepository>();
            var service = new WeatherForecastService(repositoryMock.Object);

            var requestId = Guid.NewGuid();
            var request = new WeatherForecastDeleteRequest(requestId);
            var entity = Domain.WeatherForecasts.WeatherForecast.Create(
                WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now)),
                Temperature.FromCelsius(25),
                Domain.WeatherForecasts.Enums.Summary.Mild);

            repositoryMock
                .Setup(repo => repo.GetByIdAsync(It.Is<WeatherForecastGetByIdRequest>(r => r.Id == requestId)))
                .ReturnsAsync(entity.Value);

            //Act
            var result = await service.DeleteAsync(request);

            //Assert
            Assert.True(result.IsSuccess);
            repositoryMock.Verify(r => r.DeleteAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
