using CleanArchitecture.Template.Api.Requests.WeatherForecast;
using CleanArchitecture.Template.Api.Results;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Delete;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Update;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetAll;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById;
using CleanArchitecture.Template.Domain.Users.Constants;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Template.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ISender _sender;

        public WeatherForecastController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Get a weather forecast entity by his ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize(Roles = nameof(RoleName.User))]
        [Authorize(Roles = nameof(RoleName.Admin))]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _sender.Send(new GetWeatherForecastByIdQuery(id));
            return result.Match(onSuccess: Ok, onFailure: ApiResults.Problem);
        }

        /// <summary>
        /// Get a list of weather forecasts paginated, filtered and sorted. By default, the attribute IsPaginated is true, page = 1 and page size = 15
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetWeatherForecastListRequest request)
        {
            var query = new GetWeatherForecastListQuery();
            if (request is not null)
            {
                query.Id = request.Id;
                query.StartDate = request.StartDate;
                query.EndDate = request.EndDate;
                query.TemperatureValue = request.TemperatureValue;
                query.TemperatureType = request.TemperatureType;
                query.Summary = request.Summary;
                query.Page = request.Page;
                query.PageSize = request.PageSize;
                query.IsPaginated = request.IsPaginated;
                query.SortDirection = request.SortDirection;
                query.OrderBy = request.OrderBy;
            }

            var result = await _sender.Send(query);
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
            var result = await _sender.Send(new GetAllWeatherForecastQuery());

            return result.Match(onSuccess: Ok, onFailure: ApiResults.Problem);
        }

        /// <summary>
        /// Create a weather forecast entity
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateWeatherForecastRequest request)
        {
            var result = await _sender.Send(new CreateWeatherForecastCommand(
                request.Date,
                request.Temperature,
                request.TemperatureType,
                request.Summary));

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
            var result = await _sender.Send(new DeleteWeatherForecastCommand(request.Id));

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
            var result = await _sender.Send(new UpdateWeatherForecastCommand(
                id,
                request.Date,
                request.Temperature,
                request.TemperatureType,
                request.Summary));

            return result.Match(onSuccess: Ok, onFailure: ApiResults.Problem);
        }
    }
}
