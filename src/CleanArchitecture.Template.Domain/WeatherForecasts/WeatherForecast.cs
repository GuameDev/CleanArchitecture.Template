using CleanArchitecture.Template.Domain.Base;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.Domain.WeatherForecasts.Events;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Domain.WeatherForecasts
{

    public class WeatherForecast : Entity
    {
        //Properties
        public Guid Id { get; set; }
        public WeatherDate Date { get; private set; }
        public Temperature Temperature { get; private set; }
        public Summary Summary { get; private set; }

        //Constructors
        private WeatherForecast()
        {
            Date = WeatherDate.Create(DateOnly.FromDateTime(DateTime.Now)).Value;
            Temperature = Temperature.FromCelsius(0).Value;
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
        public static Result<WeatherForecast> Create(Result<WeatherDate> dateResult, Result<Temperature> temperatureResult, Summary summary)
        {
            var entityResult = Result.Combine(dateResult, temperatureResult)
                 .OnSuccess(() => new WeatherForecast(dateResult.Value, temperatureResult.Value, summary) { Id = Guid.NewGuid() });

            if (entityResult.IsSuccess)
                entityResult.Value.Raise(new WeatherForecastCreatedDomainEvent(entityResult.Value.Id));

            return entityResult;

        }

        //Setters with DDD terminology
        public void UpdateTemperature(Temperature temperature) => Temperature = temperature;
        public void UpdateSummary(Summary newSummary) => Summary = newSummary;
        public void UpdateDate(WeatherDate date) => Date = date;
    }
}
