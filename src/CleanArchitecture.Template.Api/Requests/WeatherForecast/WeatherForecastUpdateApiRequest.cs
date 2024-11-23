using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.Temperatures;

namespace CleanArchitecture.Template.Api.Requests.WeatherForecast
{
    public record WeatherForecastUpdateApiRequest(DateOnly Date, double Temperature, TemperatureType TemperatureType, Summary Summary);
}
