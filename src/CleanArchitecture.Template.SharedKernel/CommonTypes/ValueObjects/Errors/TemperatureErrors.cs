using CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects.Errors.Base;

namespace CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects.Errors
{
    public static class TemperatureErrors
    {
        public static Error UnderZeroFahrenheit => Error.Validation($"{nameof(Temperature)}.{nameof(UnderZeroFahrenheit)}", "Temperature cannot be below absolute zero in Fahrenheit.");
        public static Error UnderZeroCelsius => Error.Validation($"{nameof(Temperature)}.{nameof(UnderZeroCelsius)}", "Temperature cannot be below absolute zero in Celsius.");

        public static Error InvalidTemperatureType => Error.Problem($"{nameof(Temperature)}.{nameof(InvalidTemperatureType)}", "Temperature type doesnt exist");
    }
}
