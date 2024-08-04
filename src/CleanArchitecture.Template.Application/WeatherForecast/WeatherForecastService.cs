using CleanArchitecture.Template.Application.Base.PageList;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll;

namespace CleanArchitecture.Template.Application.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }


        public async Task<ListAllResponse<WeatherForecastGetAllListItemResponse>> GetAll()
        {
            return await _weatherForecastRepository.GetAllAsync();
        }
    }
}
