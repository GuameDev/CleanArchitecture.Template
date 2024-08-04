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
            : base(weatherForecast =>
                (!request.StartDate.HasValue || weatherForecast.Date.Value >= request.StartDate.Value) &&
                (!request.EndDate.HasValue || weatherForecast.Date.Value <= request.EndDate.Value) &&
                (string.IsNullOrEmpty(request.Summary) || weatherForecast.Summary.ToString().Contains(request.Summary)))
        {

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
                ApplyPaging((request.Page.Value - 1) * request.PageSize.Value, request.PageSize.Value);
        }

        private static Expression<Func<Domain.Entities.WeatherForecast, object>> GetOrderByExpression(WeatherForecastOrderBy? orderBy)
        {
            return orderBy switch
            {
                WeatherForecastOrderBy.Date => weatherForecast => weatherForecast.Date,
                WeatherForecastOrderBy.TemperatureCelsius => weatherForecast => weatherForecast.Temperature.Type == TemperatureType.Celsius ? weatherForecast.Temperature.Value : weatherForecast.Temperature.ToCelsius(),
                WeatherForecastOrderBy.TemperatureFahrenheit => weatherForecast => weatherForecast.Temperature.Type == TemperatureType.Fahrenheit ? weatherForecast.Temperature.Value : weatherForecast.Temperature.ToFahrenheit(),
                _ => weatherForecast => weatherForecast.Date
            };
        }
    }
}
