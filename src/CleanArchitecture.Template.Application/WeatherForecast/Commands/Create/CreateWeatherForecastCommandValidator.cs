using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
using FluentValidation;

namespace CleanArchitecture.Template.Application.WeatherForecast.Commands.Create
{
    public class CreateWeatherForecastCommandValidator : AbstractValidator<CreateWeatherForecastCommand>
    {
        public CreateWeatherForecastCommandValidator()
        {

            RuleFor(x => x.Date)
                .NotEmpty();

            RuleFor(x => x.Temperature)
                .InclusiveBetween(TemperatureConstants.AbsoluteZeroFahrenheit, TemperatureConstants.MaxAcceptedValue)
                .WithMessage($"Temperature value must be between {TemperatureConstants.AbsoluteZeroFahrenheit} and {TemperatureConstants.MaxAcceptedValue}");

            RuleFor(x => x.TemperatureType)
                .IsInEnum();

            RuleFor(x => x.Summary)
                .IsInEnum();
        }
    }
}
