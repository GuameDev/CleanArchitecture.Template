﻿using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.WeatherDates
{
    public static class WeatherDateErrors
    {
        public static Error MinValue => Error.Validation($"{nameof(WeatherDate)}.{nameof(MinValue)}", $"The Weather Date can`t be the minimum value: {DateOnly.FromDateTime(DateTime.MinValue)}");
    }
}
