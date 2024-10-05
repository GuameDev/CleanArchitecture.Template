using FluentValidation;

namespace CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById
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
