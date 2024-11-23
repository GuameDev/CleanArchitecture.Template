using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.Temperatures;
namespace CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create.DTOs

{
    public class CreateWeatherForecastRequest
    {
        public DateOnly Date { get; set; }
        public double Temperature { get; set; }
        public TemperatureType TemperatureType { get; set; }
        public Summary Summary { get; set; }

    }
}
