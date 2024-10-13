using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Commands.Update.DTOs
{
    public record UpdateWeatherForecastRequest(Guid Id, DateOnly Date, double Temperature, TemperatureType TemperatureType, Summary Summary);
}
