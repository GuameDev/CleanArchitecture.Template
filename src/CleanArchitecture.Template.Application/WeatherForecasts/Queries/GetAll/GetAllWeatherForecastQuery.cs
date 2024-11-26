using CleanArchitecture.Template.Application.Base.Messaging;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetAll.DTOs;
using CleanArchitecture.Template.SharedKernel.Responses;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetAll
{
    public class GetAllWeatherForecastQuery : IQuery<ListAllResponse<GetAllWeatherForecastListItemResponse>>
    {
    }
}
