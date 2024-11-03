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
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;
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
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _sender.Send(new GetWeatherForecastByIdQuery(id));
            return result.Match(onSuccess: Ok, onFailure: ApiResults.Problem);
        }

        /// <summary>
        /// Retrieves a list of weather forecasts with pagination, filtering, and sorting.
        /// By default, <c>IsPaginated</c> is set to true, <c>page</c> = 1, and <c>page size</c> = 15.
        /// </summary>
        /// <remarks>
        /// <para><b>Note:</b> Swagger UI does not support arrays as query parameters directly.</para>
        /// <para>To apply dynamic filters, use the following format:</para>
        /// <list type="bullet">
        ///   <item>
        ///     <description><c>Filters[0].PropertyName=Summary&amp;Filters[0].Operator=Equals&amp;Filters[0].Value=Scorching</c></description>
        ///   </item>
        ///   <item>
        ///     <description><c>Filters[1].PropertyName=TemperatureType&amp;Filters[1].Operator=GreaterThan&amp;Filters[1].Value=20</c></description>
        ///   </item>
        /// </list>
        /// </remarks>
        /// <param name="request">The query request containing pagination, sorting, and filtering details.</param>
        /// <returns>A paginated list of weather forecasts.</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetWeatherForecastListRequest request)
        {
            var query = new GetWeatherForecastListQuery
            {
                Id = request.Id,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                TemperatureValue = request.TemperatureValue,
                TemperatureType = request.TemperatureType,
                Summary = request.Summary,
                Page = request.Page,
                PageSize = request.PageSize,
                IsPaginated = request.IsPaginated,
                SortDirection = request.SortDirection,
                OrderBy = request.OrderBy,
                Filters = request.Filters
            };

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
