using CleanArchitecture.Template.Application.WeatherForecasts.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get;
using CleanArchitecture.Template.Domain.WeatherForecasts.Criterias;
using CleanArchitecture.Template.SharedKernel.Specification;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Specifications
{
    public class WeatherForecastSpecification : BaseSpecification<Domain.WeatherForecasts.WeatherForecast>
    {
        public WeatherForecastSpecification(GetWeatherForecastListQuery query)
        {
            BuildCriteria(query);
            ApplySorting(GetOrderByExpression(query.OrderBy), query.SortDirection);

            if (query.IsPaginated)
                ApplyPaging(query.Page, query.PageSize);
        }

        private void BuildCriteria(GetWeatherForecastListQuery query)
        {
            var criterias = new List<Expression<Func<Domain.WeatherForecasts.WeatherForecast, bool>>>();

            if (query.Id is not null && !query.Id.Equals(Guid.Empty))
                criterias.Add(weatherForecast => weatherForecast.Id.Equals(query.Id));

            if (query.StartDate.HasValue && query.EndDate.HasValue)
                criterias.Add(new WeatherDateInRangeCriteria(DateOnly.FromDateTime(query.StartDate.Value), DateOnly.FromDateTime(query.EndDate.Value)).ToExpression());

            if (query.Summary is not null)
                criterias.Add(new SummaryEqualsCriteria(query.Summary.Value).ToExpression());

            if (query.TemperatureType.HasValue)
                criterias.Add(weatherForecast => weatherForecast.Temperature.Type == query.TemperatureType.Value);

            if (query.TemperatureValue.HasValue)
                criterias.Add(weatherForecast => weatherForecast.Temperature.Value >= query.TemperatureValue.Value);

            AddCriteria(criterias.ToArray());
        }

        private static Expression<Func<Domain.WeatherForecasts.WeatherForecast, object>> GetOrderByExpression(WeatherForecastOrderBy? orderBy)
        {
            return orderBy switch
            {
                WeatherForecastOrderBy.Summary => weatherForecast => weatherForecast.Summary,
                WeatherForecastOrderBy.Date => weatherForecast => weatherForecast.Date.Value,
                WeatherForecastOrderBy.Temperature => weatherForecast => weatherForecast.Temperature.Value,
                _ => weatherForecast => weatherForecast.Date.Value
            };
        }
    }
}
