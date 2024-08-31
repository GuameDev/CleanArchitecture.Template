using FluentValidation;

namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.Update
{
    public class WeatherForecastUpdateRequestValidator : AbstractValidator<WeatherForecastUpdateRequest>
    {
        public WeatherForecastUpdateRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Date).NotEmpty();
            RuleFor(x => x.Temperature).GreaterThanOrEqualTo(-273.15);
            RuleFor(x => x.TemperatureType).IsInEnum();
            RuleFor(x => x.Summary).IsInEnum();
        }
    }
}
