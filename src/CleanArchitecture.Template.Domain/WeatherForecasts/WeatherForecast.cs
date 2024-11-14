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

        //Private constructor to prevent the instantiation of a weather forecast in an invalid state
        private WeatherForecast() { }

        //Factory method 
        public static Result<WeatherForecast> Create(
            DateOnly date,
            double temperatureValue,
            TemperatureType temperatureType,
            Summary summary)
        {
            var weatherDateResult = WeatherDate.Create(date);
            var temperatureResult = Temperature.Create(temperatureValue, temperatureType);

            var entityResult = Result.Combine(
                weatherDateResult,
                temperatureResult).OnSuccess(() => new WeatherForecast()
                {
                    Id = Guid.NewGuid(),
                    Temperature = temperatureResult.Value,
                    Date = weatherDateResult.Value,
                    Summary = summary
                });

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
