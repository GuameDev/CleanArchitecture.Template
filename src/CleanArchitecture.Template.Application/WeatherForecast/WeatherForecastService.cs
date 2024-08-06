using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Application.WeatherForecast
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }


        public async Task<Result<WeatherForecastGetAllListResponse>> GetAllAsync()
        {
            var elements = await _weatherForecastRepository.GetAllAsync();
            return Result.Success(elements);
        }

        public async Task<Result<WeatherForecastGetListResponse>> GetListAsync(WeatherForecastGetListRequest request)
        {
            var elements = await _weatherForecastRepository.GetListAsync(new WeatherForecastSpecification(request));
            return Result.Success(elements);
        }
    }
}
