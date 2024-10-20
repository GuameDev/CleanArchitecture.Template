using CleanArchitecture.Template.Application.Base.Messaging;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById.DTOs;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById
{
    public record GetWeatherForecastByIdQuery(Guid Id) : IQuery<GetWeatherForecastByIdResponse>
    {
    }
}
