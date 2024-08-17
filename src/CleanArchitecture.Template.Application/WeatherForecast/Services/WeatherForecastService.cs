using CleanArchitecture.Template.Application.WeatherForecast.Repository;
using CleanArchitecture.Template.Application.WeatherForecast.Specifications;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Create;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.List;
using CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects;
using CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects.Errors;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Application.WeatherForecast.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<Result<WeatherForecastCreateResponse>> CreateAsync(WeatherForecastCreateRequest request)
        {
            //Try to create value objects
            var temperatureResult = Temperature.Create(request.Temperature, request.TemperatureType);
            var dateResult = WeatherDate.Create(request.Date);

            //Check of the result of the creation of value objects its a success
            var weatherForecastResult = Domain.Entities.WeatherForecast.Create(dateResult, temperatureResult, request.Summary);

            if (weatherForecastResult.IsFailure)
                return Result.Failure<WeatherForecastCreateResponse>(weatherForecastResult.Error);

            // Persist the entity in the repository
            var entity = weatherForecastResult.Value;
            await _weatherForecastRepository.AddAsync(entity);

            //TODO: AutoMapper
            return Result.Success(new WeatherForecastCreateResponse
                (entity.Id,
                entity.Date.Value,
                entity.Summary.ToString(),
                entity.Temperature.ToCelsius(),
                entity.Temperature.ToFahrenheit()
                ));
        }

        public async Task<Result<WeatherForecastGetAllListResponse>> GetAllAsync()
        {
            var elements = await _weatherForecastRepository.GetAllAsync();
            return Result.Success(elements);
        }

        public async Task<Result<WeatherForecastGetByIdResponse>> GetById(WeatherForecastGetByIdRequest request)
        {
            var entity = await _weatherForecastRepository.GetByIdAsync(request);

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
            var elements = await _weatherForecastRepository.GetListAsync(new WeatherForecastSpecification(request));
            return Result.Success(elements);
        }
    }
}
