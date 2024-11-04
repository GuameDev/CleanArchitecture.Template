using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Specifications;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get
{
    public class GetWeatherForecastListHandler : IRequestHandler<GetWeatherForecastListQuery, Result<GetWeatherForecastListResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetWeatherForecastListHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<GetWeatherForecastListResponse>> Handle(GetWeatherForecastListQuery query, CancellationToken cancellationToken)
        {
            var specification = new WeatherForecastDynamicSpecification(query);
            var elements = await _unitOfWork.WeatherForecastRepository.GetListAsync(specification);
            return Result.Success(elements);
        }
    }
}
