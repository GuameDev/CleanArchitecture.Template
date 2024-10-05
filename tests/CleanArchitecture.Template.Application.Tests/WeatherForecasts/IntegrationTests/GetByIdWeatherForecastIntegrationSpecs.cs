using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace CleanArchitecture.Template.Application.Tests.WeatherForecasts.IntegrationTests
{
    public class GetByIdWeatherForecastIntegrationSpecs
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IMapper> _mockMapper;
        private readonly ISender _mediator;

        public GetByIdWeatherForecastIntegrationSpecs()
        {
            var services = new ServiceCollection();

            // Register MediatR and other dependencies
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetWeatherForecastByIdHandler).Assembly));

            // Mock external dependencies
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockMapper = new Mock<IMapper>();

            services.AddSingleton(_mockUnitOfWork.Object); // Use mocked UnitOfWork
            services.AddSingleton(_mockMapper.Object);     // Use mocked Mapper

            // Register Validators (if any)
            services.AddValidatorsFromAssemblyContaining<GetWeatherForecastByIdQuery>();

            // Build the service provider
            _serviceProvider = services.BuildServiceProvider();

            // Get the mediator instance
            _mediator = _serviceProvider.GetRequiredService<IMediator>();
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
            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
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
            _mockUnitOfWork.Verify(uow => uow.WeatherForecastRepository.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()), Times.Once);
        }

        [Fact]
        public async Task GetById_ShouldReturnFailure_WhenEntityDoesNotExist()
        {
            // Arrange
            var request = new GetWeatherForecastByIdQuery(Guid.NewGuid());

            _mockUnitOfWork.Setup(uow => uow.WeatherForecastRepository.GetByIdAsync(It.IsAny<GetWeatherForecastByIdRequest>()))
                           .ReturnsAsync((Domain.WeatherForecasts.WeatherForecast)null!);

            // Act
            var result = await _mediator.Send(request);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(WeatherForecastErrors.NotFound, result.Error);
        }
    }
}
