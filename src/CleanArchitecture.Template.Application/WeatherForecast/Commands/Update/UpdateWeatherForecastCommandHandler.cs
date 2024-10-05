using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Update.DTOs;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecast.Commands.Update
{
    public class UpdateWeatherForecastHandler : IRequestHandler<UpdateWeatherForecastCommand, Result<UpdateWeatherForecastResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateWeatherForecastHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<UpdateWeatherForecastResponse>> Handle(UpdateWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.WeatherForecastRepository.GetByIdAsync(new(request.Id));

            if (entity is null)
                return Result.Failure<UpdateWeatherForecastResponse>(WeatherForecastErrors.NotFound);

            var dateResult = WeatherDate.Create(request.Date);
            var temperatureResult = Temperature.Create(request.Temperature, request.TemperatureType);

            var result = Result.Combine(dateResult, temperatureResult);

            if (result.IsFailure)
                return Result.Failure<UpdateWeatherForecastResponse>(result.Error);

            entity.UpdateSummary(request.Summary);
            entity.UpdateTemperature(temperatureResult.Value);
            entity.UpdateDate(dateResult.Value);

            await _unitOfWork.WeatherForecastRepository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            return Result.Success(_mapper.Map<UpdateWeatherForecastResponse>(entity));
        }
    }

}
