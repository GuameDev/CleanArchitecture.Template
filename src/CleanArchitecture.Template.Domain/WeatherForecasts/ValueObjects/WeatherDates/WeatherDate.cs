using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.WeatherDates
{
    public class WeatherDate : ValueObject
    {
        public DateOnly Value { get; private set; }

        private WeatherDate(DateOnly date)
        {
            Value = date;
        }

        //TODO: Implement conversion on the entity type configuration
        public WeatherDate() { }

        public static Result<WeatherDate> Create(DateOnly date)
        {
            if (IsMinValueDate(date))
                return Result.Failure<WeatherDate>(WeatherDateErrors.MinValue);

            return Result.Success(new WeatherDate(date));
        }

        private static bool IsMinValueDate(DateOnly date)
        {
            return date.Equals(DateOnly.FromDateTime(DateTime.MinValue));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
