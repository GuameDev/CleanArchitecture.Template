using CleanArchitecture.Template.Domain.Base;
using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects;
using CleanArchitecture.Template.SharedKernel.Results;

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

        public static Result<WeatherForecast> Create(Result<WeatherDate> dateResult, Result<Temperature> temperatureResult, Summary summary)
        {
            if (dateResult.IsFailure)
                return Result.Failure<WeatherForecast>(dateResult.Error);

            if (temperatureResult.IsFailure)
                return Result.Failure<WeatherForecast>(temperatureResult.Error);

            return Result.Success(new WeatherForecast(dateResult.Value, temperatureResult.Value, summary) { Id = Guid.NewGuid() });
        }


        //Methods
        public void UpdateTemperature(Temperature temperature) => Temperature = temperature;

        public void UpdateSummary(Summary newSummary) => Summary = newSummary;
    }
}
