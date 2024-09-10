using AutoMapper;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Update;

namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.Update
{
    internal class WeatherForecastUpdateResponseProfile : Profile
    {
        public WeatherForecastUpdateResponseProfile()
        {
            CreateMap<Domain.WeatherForecasts.WeatherForecast, UpdateWeatherForecastResponse>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Value))
                .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary.ToString()))
                .ForMember(dest => dest.TemperatureCelsius, opt => opt.MapFrom(src => src.Temperature.ToCelsius()))
                .ForMember(dest => dest.TemperatureFahrenheit, opt => opt.MapFrom(src => src.Temperature.ToFahrenheit()));
        }
    }
}
