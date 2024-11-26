using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Repositories;
using CleanArchitecture.Template.Application.WeatherForecasts.Specifications;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Queries.Get
{
    public class GetWeatherForecastListHandler : IRequestHandler<GetWeatherForecastListQuery, Result<GetWeatherForecastListResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public GetWeatherForecastListHandler(
            IUnitOfWork unitOfWork
            , IWeatherForecastRepository weatherForecastRepository)
        {
            _unitOfWork = unitOfWork;
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<Result<GetWeatherForecastListResponse>> Handle(GetWeatherForecastListQuery query, CancellationToken cancellationToken)
        {
            var pagedList = await _weatherForecastRepository
                .GetPaginatedListBySpecificationAsync(
                new WeatherForecastPaginatedListSpecification(query),
                wf => new GetWeatherForecastListItemResponse()
                {
                    Id = wf.Id,
                    Date = wf.Date.Value,
                    Summary = wf.Summary.ToString(),
                    TemperatureCelsius = wf.Temperature.ToCelsius(),
                    TemperatureFahrenheit = wf.Temperature.ToFahrenheit(),
                });

            return Result.Success(new GetWeatherForecastListResponse() { PagedList = pagedList });
        }
    }
}
