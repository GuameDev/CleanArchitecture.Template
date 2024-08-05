using CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects.Errors.Base;

namespace CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects.Errors
{
    public static class WeatherForecastErrors
    {
        public static Error NotFound => Error.NotFound($"WeatherForecast.NotFound", "The weather forecast with the specified identifier was not found");
    }
}
