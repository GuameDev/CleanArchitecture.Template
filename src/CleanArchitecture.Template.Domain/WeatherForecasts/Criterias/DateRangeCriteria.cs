using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Domain.WeatherForecasts.Criterias
{
    public class DateRangeCriteria : Criteria<WeatherForecast>
    {
        private readonly DateOnly _startDate;
        private readonly DateOnly _endDate;

        public DateRangeCriteria(DateOnly startDate, DateOnly endDate)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public override Expression<Func<WeatherForecast, bool>> ToExpression()
        {
            return wf => wf.Date.Value >= _startDate && wf.Date.Value <= _endDate;
        }
    }
}
