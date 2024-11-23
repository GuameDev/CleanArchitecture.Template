using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Domain.WeatherForecasts.Criterias
{
    public class SummaryEqualsCriteria : Criteria<WeatherForecast>
    {
        private readonly Summary _summary;

        public SummaryEqualsCriteria(Summary summary)
        {
            _summary = summary;
        }

        public override Expression<Func<WeatherForecast, bool>> ToExpression()
        {
            return forecast => forecast.Summary.Equals(_summary);
        }
    }
}
