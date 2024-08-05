using CleanArchitecture.Template.Application.Base.PageList;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;

namespace CleanArchitecture.Template.Application.WeatherForecast
{
    public interface IWeatherForecastService
    {
        Task<ListAllResponse<WeatherForecastGetAllListItemResponse>> GetAllAsync();
        Task<PageListResponse<WeatherForecastGetListItemResponse>> GetListAsync(WeatherForecastGetListRequest request);
    }
}
