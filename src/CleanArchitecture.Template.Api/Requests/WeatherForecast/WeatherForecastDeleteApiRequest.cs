using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Template.Api.Requests.WeatherForecast
{
    public record WeatherForecastDeleteApiRequest()
    {
        [FromRoute(Name = "id")]
        public Guid Id { get; set; }
    };
}
