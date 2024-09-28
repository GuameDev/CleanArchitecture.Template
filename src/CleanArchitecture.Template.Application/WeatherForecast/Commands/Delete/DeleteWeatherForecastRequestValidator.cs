using FluentValidation;

namespace CleanArchitecture.Template.Application.WeatherForecast.Commands.Delete
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
