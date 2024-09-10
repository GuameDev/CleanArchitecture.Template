using CleanArchitecture.Template.Application.Base.Messaging;

namespace CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById
{
    public record GetWeatherForecastByIdQuery(Guid Id) : IQuery<GetWeatherForecastByIdResponse>
    {
    }
}
