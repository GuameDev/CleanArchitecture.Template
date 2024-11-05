using CleanArchitecture.Template.Domain.Base.Events;

namespace CleanArchitecture.Template.Domain.WeatherForecasts.Events
{
    public record WeatherForecastCreatedDomainEvent(Guid Id) : DomainEvent(Id)
    {
    }
}
