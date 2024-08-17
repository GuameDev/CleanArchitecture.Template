using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Domain.WeatherForecasts.Criterias
{
    public class ExtremeWeatherCriteria : Criteria<WeatherForecast>
    {
        public override Expression<Func<WeatherForecast, bool>> ToExpression()
        {
            return weatherForecast => weatherForecast.Summary == Summary.Freezing || weatherForecast.Summary == Summary.Scorching;
        }
    }
}
