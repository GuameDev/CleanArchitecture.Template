using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.Temperatures;
using CleanArchitecture.Template.SharedKernel.Requests;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get.DTOs
{
    public class GetWeatherForecastListRequest : PageListRequest<GetWeatherForecastListPropertyName>
    {
        public Guid? Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? TemperatureValue { get; set; }
        public TemperatureType? TemperatureType { get; set; }
        public Summary? Summary { get; set; }
    }
}
