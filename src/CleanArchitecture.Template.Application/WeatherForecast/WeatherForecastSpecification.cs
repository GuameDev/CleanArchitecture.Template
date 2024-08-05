using CleanArchitecture.Template.Application.Base.PageList;
using CleanArchitecture.Template.Application.Base.Specification;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs.List;
using CleanArchitecture.Template.Domain.ValueObjects;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Application.WeatherForecast
{
    public class WeatherForecastSpecification : BaseSpecification<Domain.Entities.WeatherForecast>
    {
        public WeatherForecastSpecification(WeatherForecastGetListRequest request)
        {

            if (request.StartDate.HasValue)
                AddCriteria(weatherForecast => weatherForecast.Date.Value >= DateOnly.FromDateTime(request.StartDate.Value));

            if (request.EndDate.HasValue)
                AddCriteria(weatherForecast => weatherForecast.Date.Value <= DateOnly.FromDateTime(request.EndDate.Value));

            if (request.Summary is not null)
                AddCriteria(weatherForecast => weatherForecast.Summary.Equals(request.Summary));

            if (request.TemperatureType is not null)
                AddCriteria(weatherForecast => weatherForecast.Temperature.Type.Equals(request.TemperatureType));

            if (request.TemperatureValue is not null)
                AddCriteria(weatherForecast => weatherForecast.Temperature.Value >= request.TemperatureValue);


            switch (request.SortDirection)
            {
                case SortDirection.Ascending:
                    AddOrderBy(GetOrderByExpression(request.OrderBy));
                    break;

                case SortDirection.Descending:
                    AddOrderByDescending(GetOrderByExpression(request.OrderBy));
                    break;

                default:
                    AddOrderByDescending(GetOrderByExpression(request.OrderBy));
                    break;
            }

            if (request.IsPaginated)
                //TODO: Refactor this method to only pass as parameter Page and PageSize
                ApplyPaging((request.Page.Value - 1) * request.PageSize.Value, request.PageSize.Value, request.Page.Value, request.PageSize.Value);
        }

        private static Expression<Func<Domain.Entities.WeatherForecast, object>> GetOrderByExpression(WeatherForecastOrderBy? orderBy)
        {
            return orderBy switch
            {
                WeatherForecastOrderBy.Date => weatherForecast => weatherForecast.Date.Value,
                WeatherForecastOrderBy.TemperatureCelsius => weatherForecast => weatherForecast.Temperature.Type == TemperatureType.Celsius ? weatherForecast.Temperature.Value : weatherForecast.Temperature.ToCelsius(),
                WeatherForecastOrderBy.TemperatureFahrenheit => weatherForecast => weatherForecast.Temperature.Type == TemperatureType.Fahrenheit ? weatherForecast.Temperature.Value : weatherForecast.Temperature.ToFahrenheit(),
                _ => weatherForecast => weatherForecast.Date.Value
            };
        }
    }
}
