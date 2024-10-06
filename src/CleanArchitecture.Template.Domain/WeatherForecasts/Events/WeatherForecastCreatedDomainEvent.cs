using CleanArchitecture.Template.SharedKernel.Entities.Events;

namespace CleanArchitecture.Template.Domain.WeatherForecasts.Events
{
    public record WeatherForecastCreatedDomainEvent(Guid Id) : DomainEvent(Id)
    {
    }
}
