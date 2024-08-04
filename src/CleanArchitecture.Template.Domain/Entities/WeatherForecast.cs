using CleanArchitecture.Template.Domain.Constants;
using CleanArchitecture.Template.Domain.ValueObjects;

namespace CleanArchitecture.Template.Domain.Entities
{

    public class WeatherForecast : BaseEntity<Guid>
    {
        //Properties
        public WeatherDate Date { get; }
        public Temperature Temperature { get; private set; }
        public Summary Summary { get; private set; }

        //Constructors
        private WeatherForecast()
        {
            Date = WeatherDate.Create(DateOnly.MinValue);
            Temperature = Temperature.FromCelsius(0);
            Summary = Summary.Unknown;
        }
        private WeatherForecast(Guid id, WeatherDate date, Temperature temperature, Summary summary)
        {
            Id = id;
            Date = date;
            Temperature = temperature;
            Summary = summary;
        }

        private WeatherForecast(WeatherDate date, Temperature temperature, Summary summary)
        {
            Date = date;
            Temperature = temperature;
            Summary = summary;
        }

        //Factory methods
        public static WeatherForecast Create(WeatherDate date, Temperature temperature, Summary summary)
        {
            return new WeatherForecast(date, temperature, summary) { Id = Guid.NewGuid() };
        }

        //Methods
        public void UpdateTemperature(Temperature temperature) => Temperature = temperature;

        public void UpdateSummary(Summary newSummary) => Summary = newSummary;
    }
}
