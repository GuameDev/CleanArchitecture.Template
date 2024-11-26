using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetAll.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Repositories;
using CleanArchitecture.Template.SharedKernel.Responses;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetAll
{
    public class GetAllWeatherForecastHandler : IRequestHandler<GetAllWeatherForecastQuery, Result<ListAllResponse<GetAllWeatherForecastListItemResponse>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public GetAllWeatherForecastHandler(
            IUnitOfWork unitOfWork,
            IWeatherForecastRepository weatherForecastRepository)
        {
            _unitOfWork = unitOfWork;
            _weatherForecastRepository = weatherForecastRepository;
        }
        public async Task<Result<ListAllResponse<GetAllWeatherForecastListItemResponse>>> Handle(
            GetAllWeatherForecastQuery request,
            CancellationToken cancellationToken)
        {
            var response = await _weatherForecastRepository.GetAllAsync(
                wf => new GetAllWeatherForecastListItemResponse()
                {
                    Id = wf.Id,
                    Date = wf.Date.Value,
                    Summary = wf.Summary.ToString(),
                    TemperatureCelsius = wf.Temperature.ToCelsius(),
                    TemperatureFahrenheit = wf.Temperature.ToFahrenheit(),
                });

            return Result.Success(response);
        }
    }
}
