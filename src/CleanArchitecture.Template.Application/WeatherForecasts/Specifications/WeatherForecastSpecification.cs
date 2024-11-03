using CleanArchitecture.Template.Application.WeatherForecasts.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get;
using CleanArchitecture.Template.SharedKernel.Specification;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Specifications
{
    public class WeatherForecastSpecification : Specification<Domain.WeatherForecasts.WeatherForecast>
    {
        public WeatherForecastSpecification(GetWeatherForecastListQuery query)
        {
            ApplyDynamicFilters(query.Filters);

            ApplySorting(GetOrderByExpression(query.OrderBy), query.SortDirection);

            if (query.IsPaginated)
                ApplyPaging(query.Page, query.PageSize);
        }

        private static Expression<Func<Domain.WeatherForecasts.WeatherForecast, object>> GetOrderByExpression(WeatherForecastPropertyName? orderBy)
        {
            return orderBy switch
            {
                WeatherForecastPropertyName.Summary => weatherForecast => weatherForecast.Summary,
                WeatherForecastPropertyName.Date => weatherForecast => weatherForecast.Date.Value,
                WeatherForecastPropertyName.Temperature => weatherForecast => weatherForecast.Temperature.Value,
                _ => weatherForecast => weatherForecast.Date.Value
            };
        }
    }
}
