using CleanArchitecture.Template.Application.Base.UnitOfWork;
using CleanArchitecture.Template.Application.WeatherForecast.Queries.GetById;
using CleanArchitecture.Template.Domain.WeatherForecasts.Errors;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecast.Commands.Delete
{
    public class DeleteWeatherForecastHandler : IRequestHandler<DeleteWeatherForecastCommand, Result>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteWeatherForecastHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteWeatherForecastCommand command, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.WeatherForecastRepository.GetByIdAsync(new GetWeatherForecastByIdRequest(command.Id));

            if (entity is null)
                return Result.Failure(WeatherForecastErrors.NotFound);

            await _unitOfWork.WeatherForecastRepository.DeleteAsync(entity.Id);

            // Commit the transaction
            await _unitOfWork.CommitAsync();

            return Result.Success();
        }
    }
}
