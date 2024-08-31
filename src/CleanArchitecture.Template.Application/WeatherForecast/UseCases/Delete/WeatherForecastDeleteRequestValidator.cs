using FluentValidation;

namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.Delete
{
    public class WeatherForecastDeleteRequestValidator : AbstractValidator<WeatherForecastDeleteRequest>
    {
        public WeatherForecastDeleteRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
