using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecast.Queries.GetAll
{
    public class GetAllWeatherForecastHandler : IRequestHandler<GetAllWeatherForecastQuery, Result<GetAllWeatherForecastResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllWeatherForecastHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result<GetAllWeatherForecastResponse>> Handle(GetAllWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var elements = await _unitOfWork.WeatherForecastRepository.GetAllAsync();
            return Result.Success(elements);
        }
    }
}
