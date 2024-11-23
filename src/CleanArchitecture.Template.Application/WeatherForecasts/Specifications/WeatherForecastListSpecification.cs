using CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get.DTOs;
using CleanArchitecture.Template.Domain.WeatherForecasts.Criterias;
using CleanArchitecture.Template.SharedKernel.Specification;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Specifications
{
    public class WeatherForecastListSpecification : Specification<Domain.WeatherForecasts.WeatherForecast>
    {
        public WeatherForecastListSpecification(GetWeatherForecastListQuery query)
        {
            BuildCriteria(query);
            ApplySorting(GetOrderByExpression(query.OrderBy), query.SortDirection);

            if (query.IsPaginated)
                ApplyPaging(query.Page, query.PageSize);
        }

        private void BuildCriteria(GetWeatherForecastListQuery query)
        {
            if (query.Id is not null && !query.Id.Equals(Guid.Empty))
                AddCriteria(weatherForecast => weatherForecast.Id.Equals(query.Id));

            if (query.StartDate.HasValue && query.EndDate.HasValue)
                AddCriteria(new WeatherDateInRangeCriteria(DateOnly.FromDateTime(query.StartDate.Value), DateOnly.FromDateTime(query.EndDate.Value)).ToExpression());

            if (query.Summary is not null)
                AddCriteria(new SummaryEqualsCriteria(query.Summary.Value).ToExpression());

            if (query.TemperatureType.HasValue)
                AddCriteria(weatherForecast => weatherForecast.Temperature.Type == query.TemperatureType.Value);

            if (query.TemperatureValue.HasValue)
                AddCriteria(weatherForecast => weatherForecast.Temperature.Value >= query.TemperatureValue.Value);
        }

        private static Expression<Func<Domain.WeatherForecasts.WeatherForecast, object>> GetOrderByExpression(GetWeatherForecastListPropertyName? orderBy)
        {
            return orderBy switch
            {
                GetWeatherForecastListPropertyName.Summary => weatherForecast => weatherForecast.Summary,
                GetWeatherForecastListPropertyName.Date => weatherForecast => weatherForecast.Date.Value,
                GetWeatherForecastListPropertyName.Temperature => weatherForecast => weatherForecast.Temperature.Value,
                _ => weatherForecast => weatherForecast.Date.Value
            };
        }
    }
}
