using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Create.DTOs;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecast.Commands.Create
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
            // Try to create value objects
            var temperatureResult = Temperature.Create(request.Temperature, request.TemperatureType);
            var dateResult = WeatherDate.Create(request.Date);

            // Check if the creation of value objects is a success
            var weatherForecastResult = Domain.WeatherForecasts.WeatherForecast.Create(dateResult, temperatureResult, request.Summary);

            if (weatherForecastResult.IsFailure)
                return Result.Failure<CreateWeatherForecastResponse>(weatherForecastResult.Error);

            // Persist the entity in the repository
            var entity = weatherForecastResult.Value;
            await _unitOfWork.WeatherForecastRepository.AddAsync(entity);

            // Commit the transaction
            await _unitOfWork.CommitAsync();

            return Result.Success(_mapper.Map<CreateWeatherForecastResponse>(entity));
        }
    }
}
