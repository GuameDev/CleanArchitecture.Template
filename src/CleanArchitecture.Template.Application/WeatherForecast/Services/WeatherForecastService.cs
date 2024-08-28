using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Specifications;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Create;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Delete;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.List;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Application.WeatherForecast.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IUnitOfWork _unitOfWork;
        public WeatherForecastService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<Result<WeatherForecastCreateResponse>> CreateAsync(WeatherForecastCreateRequest request)
        {
            // Try to create value objects
            var temperatureResult = Temperature.Create(request.Temperature, request.TemperatureType);
            var dateResult = WeatherDate.Create(request.Date);

            // Check if the creation of value objects is a success
            var weatherForecastResult = Domain.WeatherForecasts.WeatherForecast.Create(dateResult, temperatureResult, request.Summary);

            if (weatherForecastResult.IsFailure)
                return Result.Failure<WeatherForecastCreateResponse>(weatherForecastResult.Error);

            // Persist the entity in the repository
            var entity = weatherForecastResult.Value;
            await _unitOfWork.WeatherForecastRepository.AddAsync(entity);

            // Commit the transaction
            await _unitOfWork.CommitAsync();

            // TODO: AutoMapper
            return Result.Success(new WeatherForecastCreateResponse(
                entity.Id,
                entity.Date.Value,
                entity.Summary.ToString(),
                entity.Temperature.ToCelsius(),
                entity.Temperature.ToFahrenheit()
            ));
        }

        public async Task<Result> DeleteAsync(WeatherForecastDeleteRequest request)
        {
            var entity = await _unitOfWork.WeatherForecastRepository.GetByIdAsync(new WeatherForecastGetByIdRequest(request.Id));

            if (entity is null)
                return Result.Failure(WeatherForecastErrors.NotFound);

            await _unitOfWork.WeatherForecastRepository.DeleteAsync(entity.Id);

            // Commit the transaction
            await _unitOfWork.CommitAsync();

            return Result.Success();
        }
        public async Task<Result<WeatherForecastGetAllListResponse>> GetAllAsync()
        {
            var elements = await _unitOfWork.WeatherForecastRepository.GetAllAsync();
            return Result.Success(elements);
        }

        public async Task<Result<WeatherForecastGetByIdResponse>> GetById(WeatherForecastGetByIdRequest request)
        {
            var entity = await _unitOfWork.WeatherForecastRepository.GetByIdAsync(request);

            return entity is not null
                ? Result.Success(new WeatherForecastGetByIdResponse(
                    entity.Id,
                    entity.Date.Value,
                    entity.Summary.ToString(),
                    entity.Temperature.ToCelsius(),
                    entity.Temperature.ToFahrenheit()
                ))
                : Result.Failure<WeatherForecastGetByIdResponse>(WeatherForecastErrors.NotFound);
        }


        public async Task<Result<WeatherForecastGetListResponse>> GetListAsync(WeatherForecastGetListRequest request)
        {
            var elements = await _unitOfWork.WeatherForecastRepository.GetListAsync(new WeatherForecastSpecification(request));
            return Result.Success(elements);
        }
    }
}
