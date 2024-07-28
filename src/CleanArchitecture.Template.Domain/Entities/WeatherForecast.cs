using CleanArchitecture.Template.Domain.Constants;
using CleanArchitecture.Template.Domain.ValueObjects;

namespace CleanArchitecture.Template.Domain.Entities
{

    public class WeatherForecast : BaseEntity<Guid>
    {
        public WeatherDate Date { get; }
        public Temperature Temperature { get; }
        public Summary Summary { get; private set; }

        private WeatherForecast(WeatherDate date, Temperature temperature, Summary summary)
        {
            Id = Guid.NewGuid();
            Date = date;
            Temperature = temperature;
            Summary = summary;
        }

        public static WeatherForecast Create(WeatherDate date, Temperature temperature, Summary summary) =>
            new WeatherForecast(date, temperature, summary);

        public void UpdateSummary(Summary newSummary) => Summary = newSummary;
    }
}
