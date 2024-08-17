using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;

namespace CleanArchitecture.Template.Application.WeatherForecast.Create
{
    public class WeatherForecastCreateRequest
    {
        public DateOnly Date { get; set; }
        public double Temperature { get; set; }
        public TemperatureType TemperatureType { get; set; }
        public Summary Summary { get; set; }

    }
}
