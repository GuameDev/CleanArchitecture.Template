using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;

namespace CleanArchitecture.Template.Api.Requests.WeatherForecast
{
    public record WeatherForecastUpdateApiRequest(DateOnly Date, double Temperature, TemperatureType TemperatureType, Summary Summary);
}
