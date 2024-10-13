using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using FluentValidation;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create
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


            RuleFor(x => x.Summary).NotEqual(Summary.Unknown).WithMessage($"Summary cannot be {Summary.Unknown}");

        }
    }
}
