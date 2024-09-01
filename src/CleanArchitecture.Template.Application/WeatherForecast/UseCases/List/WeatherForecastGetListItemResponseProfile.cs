using AutoMapper;

namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.List
{
    public class WeatherForecastGetListItemResponseProfile : Profile
    {
        public WeatherForecastGetListItemResponseProfile()
        {
            CreateMap<Domain.WeatherForecasts.WeatherForecast, WeatherForecastGetListItemResponse>()
             .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Value))
             .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary.ToString()))
             .ForMember(dest => dest.TemperatureCelsius, opt => opt.MapFrom(src => src.Temperature.ToCelsius()))
             .ForMember(dest => dest.TemperatureFahrenheit, opt => opt.MapFrom(src => src.Temperature.ToFahrenheit()));
        }
    }
}
