using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecasts.Queries.GetById.DTOs;
using CleanArchitecture.Template.Application.WeatherForecasts.Repositories;
using CleanArchitecture.Template.Domain.WeatherForecasts;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecasts.Commands.Delete
{
    public class DeleteWeatherForecastHandler : IRequestHandler<DeleteWeatherForecastCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWeatherForecastRepository _weatherForecastRepository;

        public DeleteWeatherForecastHandler(
            IUnitOfWork unitOfWork
            , IWeatherForecastRepository weatherForecastRepository)
        {
            _unitOfWork = unitOfWork;
            _weatherForecastRepository = weatherForecastRepository;
        }

        public async Task<Result> Handle(DeleteWeatherForecastCommand command, CancellationToken cancellationToken)
        {
            var entity = await _weatherForecastRepository.GetByIdAsync(new GetWeatherForecastByIdRequest(command.Id));

            if (entity is null)
                return Result.Failure(WeatherForecastErrors.NotFound);

            await _weatherForecastRepository.DeleteAsync(entity.Id);

            // Commit the transaction
            await _unitOfWork.CommitAsync(cancellationToken);

            return Result.Success();
        }
    }
}
