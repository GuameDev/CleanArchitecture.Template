using CleanArchitecture.Template.Application.Base.PageList;

namespace CleanArchitecture.Template.Application.WeatherForecast.DTOs.List
{
    public class WeatherForecastGetListRequest : PageListRequest<WeatherForecastOrderBy>
    {
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public double? TemperatureValue { get; set; }
        public string? TemperatureType { get; set; }
        public string? Summary { get; set; }
    }
}
