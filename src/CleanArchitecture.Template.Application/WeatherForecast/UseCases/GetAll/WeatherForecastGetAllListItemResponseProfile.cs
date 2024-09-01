using AutoMapper;

namespace CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetAll
{
    internal class WeatherForecastGetAllListItemResponseProfile : Profile
    {
        public WeatherForecastGetAllListItemResponseProfile()
        {
            CreateMap<Domain.WeatherForecasts.WeatherForecast, WeatherForecastGetAllListItemResponse>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Value))
                .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary.ToString()))
                .ForMember(dest => dest.TemperatureCelsius, opt => opt.MapFrom(src => src.Temperature.ToCelsius()))
                .ForMember(dest => dest.TemperatureFahrenheit, opt => opt.MapFrom(src => src.Temperature.ToFahrenheit()));
        }
    }
}
