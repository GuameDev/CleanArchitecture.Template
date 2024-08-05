using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;

namespace CleanArchitecture.Template.Application.WeatherForecast
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecastGetAllListResponse> GetAllAsync();
        Task<WeatherForecastGetListResponse> GetListAsync(WeatherForecastGetListRequest request);
    }
}
