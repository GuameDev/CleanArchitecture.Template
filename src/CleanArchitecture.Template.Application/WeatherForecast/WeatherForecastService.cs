using CleanArchitecture.Template.Application.Base.PageList;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;

namespace CleanArchitecture.Template.Application.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }


        public async Task<ListAllResponse<WeatherForecastGetAllListItemResponse>> GetAllAsync()
        {
            return await _weatherForecastRepository.GetAllAsync();
        }

        public async Task<PageListResponse<WeatherForecastGetListItemResponse>> GetListAsync(WeatherForecastGetListRequest request)
        {
            return await _weatherForecastRepository.GetListAsync(new WeatherForecastSpecification(request));
        }
    }
}
