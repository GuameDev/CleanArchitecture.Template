using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.SharedKernel.Results;


namespace CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects
{
    public class Temperature : ValueObject
    {
        public double Value { get; }
        public TemperatureType Type { get; }

        private Temperature(double value, TemperatureType type)
        {
            Value = value;
            Type = type;
        }

        //Factory Method
        public static Result<Temperature> Create(double temperatureValue, TemperatureType temperatureType) =>
          temperatureType switch
          {
              TemperatureType.Celsius => FromCelsius(temperatureValue),
              TemperatureType.Fahrenheit => FromFahrenheit(temperatureValue),
              _ => Result.Failure<Temperature>(TemperatureErrors.InvalidTemperatureType)
          };

        public static Result<Temperature> FromCelsius(double temperatureC)
        {
            if (!EnsureIsValidTemperatureValue(temperatureC, TemperatureType.Celsius))
                return Result.Failure<Temperature>(TemperatureErrors.UnderZeroCelsius);

            var temperature = new Temperature(temperatureC, TemperatureType.Celsius);
            return Result.Success(temperature);
        }

        public static Result<Temperature> FromFahrenheit(double temperatureF)
        {
            if (!EnsureIsValidTemperatureValue(temperatureF, TemperatureType.Fahrenheit))
                return Result.Failure<Temperature>(TemperatureErrors.UnderZeroFahrenheit);

            var temperature = new Temperature(temperatureF, TemperatureType.Fahrenheit);
            return Result.Success(temperature);
        }

        public double ToCelsius() =>
            Type == TemperatureType.Celsius ? Value : (Value - 32) * 5 / 9;

        public double ToFahrenheit() =>
            Type == TemperatureType.Fahrenheit ? Value : Value * 9 / 5 + 32;

        private static bool EnsureIsValidTemperatureValue(double temperatureValue, TemperatureType temperatureType) => temperatureType switch
        {
            TemperatureType.Celsius => temperatureValue >= TemperatureConstants.AbsoluteZeroCelsius,
            TemperatureType.Fahrenheit => temperatureValue >= TemperatureConstants.AbsoluteZeroFahrenheit,
            _ => false
        };

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
            yield return Type;
        }
    }
}
