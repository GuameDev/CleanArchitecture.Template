using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.WeatherForecasts
{
    public static class WeatherForecastErrors
    {
        public static Error NotFound => Error.NotFound($"WeatherForecast.NotFound", "The weather forecast with the specified identifier was not found");
        public static Error NullTemperatureValue => Error.Validation($"WeatherForecast.Temperature.NullValue", "The temperature value object cant be null");
        public static Error NullWeatherDateValue => Error.Validation($"WeatherForecast.WeatherDateValue.NullValue", "The weather date value object cant be null");
    }
}
