using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Requests;

namespace CleanArchitecture.Template.Application.WeatherForecast.DTOs.List
{
    public class WeatherForecastGetListRequest : PageListRequest<WeatherForecastOrderBy>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? TemperatureValue { get; set; }

        //TODO: create a shared kernel project
        public TemperatureType? TemperatureType { get; set; }
        public Summary? Summary { get; set; }
    }
}
