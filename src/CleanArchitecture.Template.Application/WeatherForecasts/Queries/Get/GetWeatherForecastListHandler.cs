using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Repositories;
using CleanArchitecture.Template.Application.WeatherForecasts.Specifications;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get
{
    public class GetWeatherForecastListHandler : IRequestHandler<GetWeatherForecastListQuery, Result<GetWeatherForecastListResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public GetWeatherForecastListHandler(
            IUnitOfWork unitOfWork
            , IWeatherForecastRepository weatherForecastRepository)
        {
            _unitOfWork = unitOfWork;
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<Result<GetWeatherForecastListResponse>> Handle(GetWeatherForecastListQuery query, CancellationToken cancellationToken)
        {
            var elements = await _weatherForecastRepository.GetListAsync(new WeatherForecastSpecification(query));
            return Result.Success(elements);
        }
    }
}
