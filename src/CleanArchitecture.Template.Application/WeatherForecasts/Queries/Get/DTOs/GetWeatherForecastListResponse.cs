using CleanArchitecture.Template.SharedKernel.Responses;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get.DTOs
{
    public class GetWeatherForecastListResponse
    {
        public PageListResponse<GetWeatherForecastListItemResponse> PagedList { get; set; }
    }
}
