using CleanArchitecture.Template.Application.Base.PageList;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll;

namespace CleanArchitecture.Template.Application.WeatherForecast
{
    public interface IWeatherForecastService
    {
        Task<ListAllResponse<WeatherForecastGetAllListItemResponse>> GetAll();
    }
}
