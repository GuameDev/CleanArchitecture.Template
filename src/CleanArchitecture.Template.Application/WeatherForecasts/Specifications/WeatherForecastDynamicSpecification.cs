using CleanArchitecture.Template.Application.WeatherForecasts.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get;
using CleanArchitecture.Template.SharedKernel.Specification.DynamicSpecifications;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Specifications
{
    public class WeatherForecastDynamicSpecification : DynamicSpecification<Domain.WeatherForecasts.WeatherForecast, WeatherForecastPropertyName>
    {
        public WeatherForecastDynamicSpecification(GetWeatherForecastListQuery query)
        {
            ApplyDynamicFilters(query.Filters);

            ApplySorting(query.OrderBy ?? WeatherForecastPropertyName.Date, query.SortDirection);

            if (query.IsPaginated)
                ApplyPaging(query.Page, query.PageSize);
        }
    }
}
