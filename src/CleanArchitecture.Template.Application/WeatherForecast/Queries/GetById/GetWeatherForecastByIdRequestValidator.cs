using FluentValidation;

namespace CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById
{
    public class GetWeatherForecastByIdRequestValidator : AbstractValidator<GetWeatherForecastByIdRequest>
    {
        public GetWeatherForecastByIdRequestValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
