using FluentValidation;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Commands.Delete
{
    public class DeleteWeatherForecastRequestValidator : AbstractValidator<DeleteWeatherForecastCommand>
    {
        public DeleteWeatherForecastRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
