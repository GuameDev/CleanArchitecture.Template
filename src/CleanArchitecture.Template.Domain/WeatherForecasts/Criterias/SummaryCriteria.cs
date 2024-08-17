using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Domain.WeatherForecasts.Criterias
{
    public class SummaryCriteria : Criteria<WeatherForecast>
    {
        private readonly string _summary;

        public SummaryCriteria(string summary)
        {
            _summary = summary;
        }

        public override Expression<Func<WeatherForecast, bool>> ToExpression()
        {
            return forecast => forecast.Summary.ToString().Contains(_summary);
        }
    }
}
