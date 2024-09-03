using AutoMapper;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Create;

namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.Create
{
    internal class WeatherForecastCreateResponseProfile : Profile
    {
        public WeatherForecastCreateResponseProfile()
        {
            CreateMap<Domain.WeatherForecasts.WeatherForecast, CreateWeatherForecastResponse>()
               .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Value))
               .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary.ToString()))
               .ForMember(dest => dest.TemperatureCelsius, opt => opt.MapFrom(src => src.Temperature.ToCelsius()))
               .ForMember(dest => dest.TemperatureFahrenheit, opt => opt.MapFrom(src => src.Temperature.ToFahrenheit()));
        }
    }
}
