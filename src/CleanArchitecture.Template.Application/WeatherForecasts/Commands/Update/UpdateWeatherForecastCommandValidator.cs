using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
using FluentValidation;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Commands.Update
{
    public class UpdateWeatherForecastCommandValidator : AbstractValidator<UpdateWeatherForecastCommand>
    {
        public UpdateWeatherForecastCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id is required.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Date is required.");
            RuleFor(x => x.Temperature)
               .InclusiveBetween(TemperatureConstants.AbsoluteZeroFahrenheit, TemperatureConstants.MaxAcceptedValue)
               .WithMessage($"Temperature value must be between {TemperatureConstants.AbsoluteZeroFahrenheit} and {TemperatureConstants.MaxAcceptedValue}");
            RuleFor(x => x.Summary).NotEmpty().WithMessage("Summary is required.");
        }
    }
}
