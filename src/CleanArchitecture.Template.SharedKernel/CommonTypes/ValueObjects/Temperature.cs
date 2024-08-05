using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Constants;

namespace CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects
{

    public class Temperature
    {
        public double Value { get; }
        public TemperatureType Type { get; }

        private Temperature(double value, TemperatureType type)
        {
            Value = value;
            Type = type;
        }

        public static Temperature FromCelsius(double temperatureC)
        {
            ValidateCelsius(temperatureC);
            return new Temperature(temperatureC, TemperatureType.Celsius);
        }

        public static Temperature FromFahrenheit(double temperatureF)
        {
            ValidateFahrenheit(temperatureF);
            return new Temperature(temperatureF, TemperatureType.Fahrenheit);
        }

        public double ToCelsius() =>
            Type == TemperatureType.Celsius ? Value : (Value - 32) * 5 / 9;

        public double ToFahrenheit() =>
            Type == TemperatureType.Fahrenheit ? Value : (Value * 9 / 5) + 32;

        private static void ValidateCelsius(double temperatureC)
        {
            if (temperatureC < TemperatureConstants.AbsoluteZeroCelsius)
                throw new Exception("Temperature cannot be below absolute zero in Celsius.");
        }

        private static void ValidateFahrenheit(double temperatureF)
        {
            if (temperatureF < TemperatureConstants.AbsoluteZeroFahrenheit)
                throw new Exception("Temperature cannot be below absolute zero in Fahrenheit.");
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Temperature other) return false;
            return Value.Equals(other.Value) && Type == other.Type;
        }

        public override int GetHashCode() => HashCode.Combine(Value, Type);

    }
}





