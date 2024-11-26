using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecasts.Commands.Update.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Repositories;
using CleanArchitecture.Template.Domain.WeatherForecasts;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.Temperatures;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects.WeatherDates;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Commands.Update
{
    public class UpdateWeatherForecastHandler : IRequestHandler<UpdateWeatherForecastCommand, Result<UpdateWeatherForecastResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public UpdateWeatherForecastHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IWeatherForecastRepository weatherForecastRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<Result<UpdateWeatherForecastResponse>> Handle(UpdateWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            var entity = await _weatherForecastRepository.GetByIdAsync(request.Id);

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

            _weatherForecastRepository.Update(entity);
            await _unitOfWork.CommitAsync();

            return Result.Success(_mapper.Map<UpdateWeatherForecastResponse>(entity));
        }
    }

}
