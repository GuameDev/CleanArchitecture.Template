
using CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects.Errors;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects
{
    public class WeatherDate : ValueObject
    {
        public DateOnly Value { get; private set; }

        private WeatherDate() { }

        private WeatherDate(DateOnly date)
        {
            Value = date;
        }

        public static Result<WeatherDate> Create(DateOnly date)
        {
            if (!IsValidDate(date))
                return Result.Failure<WeatherDate>(WeatherDateErrors.MinValue);

            return Result.Success(new WeatherDate(date));
        }
        private static bool IsValidDate(DateOnly date)
        {
            return !date.Equals(DateOnly.FromDateTime(DateTime.MinValue));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
