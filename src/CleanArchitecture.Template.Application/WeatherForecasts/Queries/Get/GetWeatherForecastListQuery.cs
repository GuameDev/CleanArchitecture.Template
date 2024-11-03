using CleanArchitecture.Template.Application.Base.Messaging;
using CleanArchitecture.Template.Application.WeatherForecasts.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get.DTOs;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.SharedKernel.Requests;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get
{
    public class GetWeatherForecastListQuery : PageListRequest<WeatherForecastPropertyName>, IQuery<GetWeatherForecastListResponse>
    {
        public Guid? Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? TemperatureValue { get; set; }
        public TemperatureType? TemperatureType { get; set; }
        public Summary? Summary { get; set; }
        public IEnumerable<DynamicFilterRequest<WeatherForecastPropertyName>> Filters { get; set; } = new List<DynamicFilterRequest<WeatherForecastPropertyName>>();
    }
}

