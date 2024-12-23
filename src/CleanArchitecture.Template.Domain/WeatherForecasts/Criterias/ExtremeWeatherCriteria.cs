﻿using CleanArchitecture.Template.Domain.WeatherForecasts.Constants;
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
