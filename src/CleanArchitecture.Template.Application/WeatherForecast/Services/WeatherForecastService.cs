using AutoMapper;
using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Commands.Create;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetAll;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById;
using CleanArchitecture.Template.Application.WeatherForecast.Specifications;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.Delete;
using CleanArchitecture.Template.Application.WeatherForecast.UseCases.List;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.SharedKernel.CommonTypes;
using CleanArchitecture.Template.SharedKernel.Results;

namespace CleanArchitecture.Template.Application.WeatherForecast.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WeatherForecastService(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result> DeleteAsync(WeatherForecastDeleteRequest request)
        {
            //TODO: Refactor fluent validation with mediator pattern (MediatR)
            var validator = new WeatherForecastDeleteRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return Result.Failure<CreateWeatherForecastResponse>(Error.RequestValidation(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))));


            var entity = await _unitOfWork.WeatherForecastRepository.GetByIdAsync(new GetWeatherForecastByIdRequest(request.Id));

            if (entity is null)
                return Result.Failure(WeatherForecastErrors.NotFound);

            await _unitOfWork.WeatherForecastRepository.DeleteAsync(entity.Id);

            // Commit the transaction
            await _unitOfWork.CommitAsync();

            return Result.Success();
        }

        public async Task<Result<GetAllWeatherForecastResponse>> GetAllAsync()
        {
            var elements = await _unitOfWork.WeatherForecastRepository.GetAllAsync();
            return Result.Success(elements);
        }

        public async Task<Result<GetWeatherForecastByIdResponse>> GetById(GetWeatherForecastByIdRequest request)
        {

            var validator = new GetWeatherForecastByIdRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
                return Result.Failure<GetWeatherForecastByIdResponse>(Error.RequestValidation(string.Join(", ", validationResult.Errors.Select(e => e.ErrorMessage))));

            var entity = await _unitOfWork.WeatherForecastRepository.GetByIdAsync(request);

            return entity is not null
                ? Result.Success(_mapper.Map<GetWeatherForecastByIdResponse>(entity))
                : Result.Failure<GetWeatherForecastByIdResponse>(WeatherForecastErrors.NotFound);
        }

        public async Task<Result<WeatherForecastGetListResponse>> GetListAsync(WeatherForecastGetListRequest request)
        {
            var elements = await _unitOfWork.WeatherForecastRepository.GetListAsync(new WeatherForecastSpecification(request));
            return Result.Success(elements);
        }
    }
}
