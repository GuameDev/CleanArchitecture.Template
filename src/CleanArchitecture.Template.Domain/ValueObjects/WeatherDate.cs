namespace CleanArchitecture.Template.Domain.ValueObjects
{
    public class WeatherDate
    {
        public DateOnly Value { get; private set; }

        private WeatherDate() { }

        private WeatherDate(DateOnly date)
        {
            Value = date;
        }

        public static WeatherDate Create(DateOnly date)
        {
            //Perform validations
            return new WeatherDate(date);
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (WeatherDate)obj;
            return Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
