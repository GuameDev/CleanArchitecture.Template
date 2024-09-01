using FluentValidation;

namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetById
{
    public class WeatherForecastGetByIdRequestValidator : AbstractValidator<WeatherForecastGetByIdRequest>
    {
        public WeatherForecastGetByIdRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
