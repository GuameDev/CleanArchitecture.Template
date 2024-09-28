using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Specifications;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecast.Queries.Get
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
            var elements = await _unitOfWork.WeatherForecastRepository.GetListAsync(new WeatherForecastSpecification(query));
            return Result.Success(elements);
        }
    }
}
