using FluentValidation;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById
{
    public class GetWeatherForecastByIdQueryValidator : AbstractValidator<GetWeatherForecastByIdQuery>
    {
        public GetWeatherForecastByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
