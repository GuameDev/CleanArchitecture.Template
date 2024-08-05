using CleanArchitecture.Template.SharedKernel.Responses.PageList;

namespace CleanArchitecture.Template.Application.WeatherForecast.DTOs.List
{
    public record WeatherForecastGetListResponse(PageListResponse<WeatherForecastGetListItemResponse> Response);
}
