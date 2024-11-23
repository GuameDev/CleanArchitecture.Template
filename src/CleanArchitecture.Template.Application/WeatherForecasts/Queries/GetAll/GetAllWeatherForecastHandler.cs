using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetAll.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Repository;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetAll
{
    public class GetAllWeatherForecastHandler : IRequestHandler<GetAllWeatherForecastQuery, Result<GetAllWeatherForecastResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public GetAllWeatherForecastHandler(
            IUnitOfWork unitOfWork,
            IWeatherForecastRepository weatherForecastRepository)
        {
            _unitOfWork = unitOfWork;
            _weatherForecastRepository = weatherForecastRepository;
        }
        public async Task<Result<GetAllWeatherForecastResponse>> Handle(GetAllWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var elements = await _weatherForecastRepository.GetAllAsync();
            return Result.Success(elements);
        }
    }
}
