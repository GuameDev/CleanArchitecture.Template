using CleanArchitecture.Template.Application.WeatherForecast.UseCases.GetById;
using CleanArchitecture.Template.SharedKernel.Results;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecast.Queries
{
    public record WeatherForecastGetByIdQuery(Guid Id) : IRequest<Result<WeatherForecastGetByIdResponse>>;

}
