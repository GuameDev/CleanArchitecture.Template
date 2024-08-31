using AutoMapper;

namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetById
{
    internal class WeatherForecastGetByIdResponseProfile : Profile
    {
        public WeatherForecastGetByIdResponseProfile()
        {
            CreateMap<Domain.WeatherForecasts.WeatherForecast, WeatherForecastGetByIdResponse>()
             .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Value))
             .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary.ToString()))
             .ForMember(dest => dest.TemperatureCelsius, opt => opt.MapFrom(src => src.Temperature.ToCelsius()))
             .ForMember(dest => dest.TemperatureFahrenheit, opt => opt.MapFrom(src => src.Temperature.ToFahrenheit()));
        }
    }
}
