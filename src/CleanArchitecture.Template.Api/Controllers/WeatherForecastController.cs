using CleanArchitecture.Template.Api.Requests.WeatherForecast;
using CleanArchitecture.Template.Api.Results;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Create;
using CleanArchitecture.Template.Application.WeatherForecast.Services;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Delete;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.List;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Template.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _weatherForecastService;
        private readonly ISender _sender;

        public WeatherForecastController(

            IWeatherForecastService weatherForecastService, ISender sender
            )
        {
            _weatherForecastService = weatherForecastService;
            _sender = sender;
        }

        /// <summary>
        /// Get a weather forecast entity by his ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _weatherForecastService.GetById(new(id));
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
        public async Task<IActionResult> GetAll()
        {
            var result = await _weatherForecastService.GetAllAsync();

            return result.Match(onSuccess: Ok, onFailure: ApiResults.Problem);
        }

        /// <summary>
        /// Create a weather forecast entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWeatherForecastCommand request)
        {
            var result = await _sender.Send(request);

            return result.Match(
                onSuccess: () => CreatedAtAction(nameof(GetById), new { id = result.Value.Id }, result.Value),
                onFailure: ApiResults.Problem
            );
        }

        /// <summary>
        /// Delete a Weather forecast entity by his ID
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] WeatherForecastDeleteApiRequest request)
        {
            var result = await _weatherForecastService.DeleteAsync(new WeatherForecastDeleteRequest(request.Id));

            return result.Match(
                onSuccess: Ok,
                onFailure: ApiResults.Problem
            );
        }

        /// <summary>
        /// Update an existing weather forecast entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] WeatherForecastUpdateApiRequest request)
        {
            var result = await _weatherForecastService.UpdateAsync(new(
                id,
                request.Date,
                request.Temperature,
                request.TemperatureType,
                request.Summary));

            return result.Match(onSuccess: Ok, onFailure: ApiResults.Problem);
        }
    }
}
