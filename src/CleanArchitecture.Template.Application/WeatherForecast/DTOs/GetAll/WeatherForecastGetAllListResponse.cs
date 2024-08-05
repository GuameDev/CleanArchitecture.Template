using CleanArchitecture.Template.SharedKernel.Responses.PageList;

namespace CleanArchitecture.Template.Application.WeatherForecast.DTOs.GetAll
{
    public record WeatherForecastGetAllListResponse(ListAllResponse<WeatherForecastGetAllListItemResponse> Response);
}
