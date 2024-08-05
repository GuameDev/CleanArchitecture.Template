
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
            //Perform validations
            return Result.Success(new WeatherDate(date));
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Value;
        }
    }
}
