namespace CleanArchitecture.Template.Domain.ValueObjects
{
    public class WeatherDate
    {
        public DateOnly Date { get; private set; }


        private WeatherDate(DateOnly date)
        {
            Date = date;
        }

        public WeatherDate Create(DateOnly date)
        {
            //Perform validations
            return new WeatherDate(date);
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var other = (WeatherDate)obj;
            return Date.Equals(other.Date);
        }

        public override int GetHashCode()
        {
            return Date.GetHashCode();
        }
    }
}
