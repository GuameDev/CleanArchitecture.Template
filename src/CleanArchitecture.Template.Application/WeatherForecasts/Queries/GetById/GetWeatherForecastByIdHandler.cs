using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById
{
    public class GetWeatherForecastByIdHandler : IRequestHandler<GetWeatherForecastByIdQuery, Result<GetWeatherForecastByIdResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetWeatherForecastByIdHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetWeatherForecastByIdResponse>> Handle(GetWeatherForecastByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.WeatherForecastRepository.GetByIdAsync(new GetWeatherForecastByIdRequest(query.Id));

            if (entity == null)
                return Result.Failure<GetWeatherForecastByIdResponse>(WeatherForecastErrors.NotFound);

            var response = _mapper.Map<GetWeatherForecastByIdResponse>(entity);
            return Result.Success(response);
        }
    }
}
