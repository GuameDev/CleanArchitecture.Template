using CleanArchitecture.Template.Application.Base.PageList;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Template.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAllWeatherForecast")]
        public ActionResult<PageListResponse<WeatherForecastGetListItemResponse>> GetAll()
        {
            var elements = Enumerable.Range(1, 5).Select(index => new WeatherForecastGetListItemResponse(default, default, default, default)
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                TemperatureF = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            return Ok(new PageListResponse<WeatherForecastGetListItemResponse>
            {
                Elements = elements,
                Page = 0,
                PageSize = elements.Length,
                TotalCount = elements.Length
            });
        }
    }
}
