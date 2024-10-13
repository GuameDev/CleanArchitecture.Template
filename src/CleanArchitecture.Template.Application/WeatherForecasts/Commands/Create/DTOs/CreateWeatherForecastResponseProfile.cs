using AutoMapper;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create.DTOs
{
    internal class CreateWeatherForecastResponseProfile : Profile
    {
        public CreateWeatherForecastResponseProfile()
        {
            CreateMap<Domain.WeatherForecasts.WeatherForecast, CreateWeatherForecastResponse>()
               .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Value))
               .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary.ToString()))
               .ForMember(dest => dest.TemperatureCelsius, opt => opt.MapFrom(src => src.Temperature.ToCelsius()))
               .ForMember(dest => dest.TemperatureFahrenheit, opt => opt.MapFrom(src => src.Temperature.ToFahrenheit()));
        }
    }
}
