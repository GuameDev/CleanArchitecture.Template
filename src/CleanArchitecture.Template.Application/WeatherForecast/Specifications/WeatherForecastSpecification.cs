using CleanArchitecture.Template.Application.WeatherForecast.DTOs;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.List;
using CleanArchitecture.Template.Domain.WeatherForecasts.Criterias;
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

            if (request.IsPaginated)
                ApplyPaging(request.Page, request.PageSize);
        }

        private void BuildCriteria(WeatherForecastGetListRequest request)
        {
            var criterias = new List<Expression<Func<Domain.WeatherForecasts.WeatherForecast, bool>>>();

            if (request.Id is not null && !request.Id.Equals(Guid.Empty))
                criterias.Add(weatherForecast => weatherForecast.Id.Equals(request.Id));

            if (request.StartDate.HasValue && request.EndDate.HasValue)
                criterias.Add(new DateRangeCriteria(DateOnly.FromDateTime(request.StartDate.Value), DateOnly.FromDateTime(request.EndDate.Value)).ToExpression());

            if (request.Summary is not null)
                criterias.Add(new SummaryCriteria(request.Summary.Value).ToExpression());

            if (request.TemperatureType.HasValue)
                criterias.Add(weatherForecast => weatherForecast.Temperature.Type == request.TemperatureType.Value);

            if (request.TemperatureValue.HasValue)
                criterias.Add(weatherForecast => weatherForecast.Temperature.Value >= request.TemperatureValue.Value);

            AddCriteria([.. criterias]);
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
