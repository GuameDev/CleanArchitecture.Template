using CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects.Errors.Base;

namespace CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects.Errors
{
    public static class WeatherDateErrors
    {
        public static Error MinValue => Error.Validation($"{nameof(WeatherDate)}.{nameof(MinValue)}", $"The Weather Date can`t be the minimum value: {DateOnly.FromDateTime(DateTime.MinValue)}");
    }
}
