using AutoMapper;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById
{
    internal class GetWeatherForecastByIdResponseProfile : Profile
    {
        public GetWeatherForecastByIdResponseProfile()
        {
            CreateMap<Domain.WeatherForecasts.WeatherForecast, GetWeatherForecastByIdResponse>()
             .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date.Value))
             .ForMember(dest => dest.Summary, opt => opt.MapFrom(src => src.Summary.ToString()))
             .ForMember(dest => dest.TemperatureCelsius, opt => opt.MapFrom(src => src.Temperature.ToCelsius()))
             .ForMember(dest => dest.TemperatureFahrenheit, opt => opt.MapFrom(src => src.Temperature.ToFahrenheit()));
        }
    }
}
