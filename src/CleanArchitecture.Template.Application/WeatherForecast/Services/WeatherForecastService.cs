using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Specifications;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Create;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Delete;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.List;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Update;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.Domain.WeatherForecasts.ValueObjects;
using CleanArchitecture.Template.SharedKernel.CommonTypes;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Application.WeatherForecast.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IUnitOfWork _unitOfWork;
        public WeatherForecastService(
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result<WeatherForecastCreateResponse>> CreateAsync(WeatherForecastCreateRequest request)
        {
            //Fluent validation
            var validator = new WeatherForecastCreateRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return Result.Failure<WeatherForecastCreateResponse>(Error.RequestValidation(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))));

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
            //TODO: Refactor fluent validation with mediator pattern (MediatR)
            var validator = new WeatherForecastDeleteRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return Result.Failure<WeatherForecastCreateResponse>(Error.RequestValidation(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))));


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

            var validator = new WeatherForecastGetByIdRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return Result.Failure<WeatherForecastGetByIdResponse>(Error.RequestValidation(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))));

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

        public async Task<Result<WeatherForecastUpdateResponse>> UpdateAsync(WeatherForecastUpdateRequest request)
        {
            var validator = new WeatherForecastUpdateRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return Result.Failure<WeatherForecastUpdateResponse>(Error.RequestValidation(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))));

            var entity = await _unitOfWork.WeatherForecastRepository.GetByIdAsync(new(request.Id));

            if (entity is null)
                return Result.Failure<WeatherForecastUpdateResponse>(WeatherForecastErrors.NotFound);

            var dateResult = WeatherDate.Create(request.Date);
            var temperatureResult = Temperature.Create(request.Temperature, request.TemperatureType);

            var result = Result.Combine(dateResult, temperatureResult);

            if (result.IsFailure)
                return Result.Failure<WeatherForecastUpdateResponse>(result.Error);

            entity.UpdateSummary(request.Summary);
            entity.UpdateTemperature(temperatureResult.Value);
            entity.UpdateDate(dateResult.Value);

            await _unitOfWork.WeatherForecastRepository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();

            //TODO:Automapper
            return Result.Success(new WeatherForecastUpdateResponse(
                entity.Id,
                entity.Date.Value,
                entity.Summary.ToString(),
                entity.Temperature.ToCelsius(),
                entity.Temperature.ToFahrenheit()));
        }
    }
}
