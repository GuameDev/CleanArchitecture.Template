using CleanArchitecture.Template.Application.WeatherForecast;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;
using CleanArchitecture.Template.SharedKernel.Responses.PageList;
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
        [Route("all")]
        public async Task<ActionResult<ListAllResponse<WeatherForecastGetAllListItemResponse>>> GetAll()
        {
            return Ok(await _weatherForecastService.GetAllAsync());
        }

        /// <summary>
        /// Get a list of weather forecasts paginated, filtered and sorted. By default, the attribute IsPaginated is true, page = 1 and page size = 15
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<PageListResponse<WeatherForecastGetListItemResponse>>> Get([FromQuery] WeatherForecastGetListRequest request)
        {
            return Ok(await _weatherForecastService.GetListAsync(request));
        }
    }
}
