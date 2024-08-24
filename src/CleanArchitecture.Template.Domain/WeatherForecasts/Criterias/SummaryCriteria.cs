using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Domain.WeatherForecasts.Criterias
{
    public class SummaryCriteria : Criteria<WeatherForecast>
    {
        private readonly Summary _summary;

        public SummaryCriteria(Summary summary)
        {
            _summary = summary;
        }

        public override Expression<Func<WeatherForecast, bool>> ToExpression()
        {
            return forecast => forecast.Summary.Equals(_summary);
        }
    }
}
