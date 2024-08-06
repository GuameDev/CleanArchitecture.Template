using CleanArchitecture.Template.Api.Results;
using CleanArchitecture.Template.Application.WeatherForecast;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;
using CleanArchitecture.Template.SharedKernel.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Template.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _weatherForecastService;

        public WeatherForecastController(

            IWeatherForecastService weatherForecastService)
        {
            _weatherForecastService = weatherForecastService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _weatherForecastService.GetAllAsync();

            return result.Match(onSuccess: Ok, onFailure: ApiResults.Problem);
        }

        /// <summary>
        /// Get a list of weather forecasts paginated, filtered and sorted. By default, the attribute IsPaginated is true, page = 1 and page size = 15
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] WeatherForecastGetListRequest request)
        {
            var result = await _weatherForecastService.GetListAsync(request);

            return result.Match(onSuccess: Ok, onFailure: ApiResults.Problem);
        }
    }
}