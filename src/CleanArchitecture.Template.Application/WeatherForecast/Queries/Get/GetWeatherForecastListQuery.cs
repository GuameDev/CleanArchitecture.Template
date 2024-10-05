﻿using CleanArchitecture.Template.Application.Base.Messaging;
using CleanArchitecture.Template.Application.WeatherForecast.DTOs;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.Get.DTOs;
using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
using CleanArchitecture.Template.SharedKernel.Requests;

namespace CleanArchitecture.Template.Application.WeatherForecast.Queries.Get
{
    public class GetWeatherForecastListQuery : PageListRequest<WeatherForecastOrderBy>, IQuery<GetWeatherForecastListResponse>
    {
        public Guid? Id { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public double? TemperatureValue { get; set; }
        public TemperatureType? TemperatureType { get; set; }
        public Summary? Summary { get; set; }
    }
}

