﻿using CleanArchitecture.Template.Domain.WeatherForecasts.Enums;
namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.Create

{
    public class WeatherForecastCreateRequest
    {
        public DateOnly Date { get; set; }
        public double Temperature { get; set; }
        public TemperatureType TemperatureType { get; set; }
        public Summary Summary { get; set; }

    }
}
