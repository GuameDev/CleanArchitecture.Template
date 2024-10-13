using CleanArchitecture.Template.Application.Base.Messaging;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById
{
    public record GetWeatherForecastByIdQuery(Guid Id) : IQuery<GetWeatherForecastByIdResponse>
    {
    }
}
