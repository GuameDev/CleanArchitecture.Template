using CleanArchitecture.Template.Application.WeatherForecast.DTOs;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.List;
using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Specification;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Application.WeatherForecast.Specifications
{
    public class WeatherForecastSpecification : BaseSpecification<Domain.WeatherForecasts.WeatherForecast>
    {
        public WeatherForecastSpecification(WeatherForecastGetListRequest request)
        {
            BuildCriteria(request);
            ApplySorting(request.OrderBy, request.SortDirection);
            ApplyPaging(request.Page ?? 1, request.PageSize ?? 15);
        }

        private void BuildCriteria(WeatherForecastGetListRequest request)
        {
            var criteria = new List<Expression<Func<Domain.WeatherForecasts.WeatherForecast, bool>>>();

            if (request.StartDate.HasValue)
                criteria.Add(weatherForecast => weatherForecast.Date.Value >= DateOnly.FromDateTime(request.StartDate.Value));

            if (request.EndDate.HasValue)
                criteria.Add(weatherForecast => weatherForecast.Date.Value <= DateOnly.FromDateTime(request.EndDate.Value));

            if (request.Summary is not null)
                AddCriteria(weatherForecast => weatherForecast.Summary.Equals(request.Summary));

            if (request.TemperatureType.HasValue)
                criteria.Add(weatherForecast => weatherForecast.Temperature.Type == request.TemperatureType.Value);

            if (request.TemperatureValue.HasValue)
                criteria.Add(weatherForecast => weatherForecast.Temperature.Value >= request.TemperatureValue.Value);

            AddCriteria(criteria.ToArray());
        }

        private void ApplySorting(WeatherForecastOrderBy? orderBy, SortDirection sortDirection)
        {
            var orderByExpression = GetOrderByExpression(orderBy);

            if (sortDirection == SortDirection.Ascending)
                SetOrderBy(orderByExpression);
            else
                SetOrderByDescending(orderByExpression);
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
