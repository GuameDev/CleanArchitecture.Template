using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create.DTOs;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Commands.Create
{
    public class CreateWeatherForecastHandler : IRequestHandler<CreateWeatherForecastCommand, Result<CreateWeatherForecastResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateWeatherForecastHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<CreateWeatherForecastResponse>> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            // Validate other business rules by creating the WeatherForecast entity
            var weatherForecastResult = Domain.WeatherForecasts.WeatherForecast.Create(
                request.Date,
                request.Temperature,
                request.TemperatureType,
                request.Summary);

            if (weatherForecastResult.IsFailure)
                return Result.Failure<CreateWeatherForecastResponse>(weatherForecastResult.Error);

            // Persist the valid entity in the repository
            var entity = weatherForecastResult.Value;
            await _unitOfWork.WeatherForecastRepository.AddAsync(entity);

            // Commit the transaction
            await _unitOfWork.CommitAsync(cancellationToken);

            // Map the entity to response DTO and return success
            return Result.Success(_mapper.Map<CreateWeatherForecastResponse>(entity));
        }
    }
}
