using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;

namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.Update
{
    public record WeatherForecastUpdateRequest(Guid Id, DateOnly Date, double Temperature, TemperatureType TemperatureType, Summary Summary);
}
