using CleanArchitecture.Template.Application.WeatherForecast.DTOs;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Requests;

namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.List
{
    public class WeatherForecastGetListRequest : PageListRequest<WeatherForecastOrderBy>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? TemperatureValue { get; set; }
        public TemperatureType? TemperatureType { get; set; }
        public Summary? Summary { get; set; }
    }
}
