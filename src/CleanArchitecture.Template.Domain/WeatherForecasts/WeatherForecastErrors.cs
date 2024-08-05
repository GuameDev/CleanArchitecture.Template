using CleanArchitecture.Template.SharedKernel.Errors;

namespace CleanArchitecture.Template.Domain.WeatherForecasts
{
    public static class WeatherForecastErrors
    {
        public static Error NotFound => Error.NotFound($"{nameof(WeatherForecast)}.{nameof(NotFound)}", "The weather forecast with the specified identifier was not found");
    }
}
