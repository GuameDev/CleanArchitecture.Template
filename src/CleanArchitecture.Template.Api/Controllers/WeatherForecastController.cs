using CleanArchitecture.Template.Api.Results;
using CleanArchitecture.Template.Application.WeatherForecast.Services;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Create;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.List;
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

        /// <summary>
        /// Get a weather forecast entity by his ID
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] WeatherForecastGetByIdRequest request)
        {
            var result = await _weatherForecastService.GetById(request);
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

        /// <summary>
        /// Get a list of all weather forecasts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var result = await _weatherForecastService.GetAllAsync();

            return result.Match(onSuccess: Ok, onFailure: ApiResults.Problem);
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] WeatherForecastCreateRequest request)
        {
            var result = await _weatherForecastService.CreateAsync(request);

            return result.Match(
                onSuccess: () => CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value),
                onFailure: ApiResults.Problem
            );
        }
    }
}
