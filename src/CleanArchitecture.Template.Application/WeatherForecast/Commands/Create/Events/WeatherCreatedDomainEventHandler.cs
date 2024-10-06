using CleanArchitecture.Template.Domain.WeatherForecasts.Events;
using MediatR;

namespace CleanArchitecture.Template.Application.WeatherForecast.Commands.Create.Events
{
    internal sealed class WeatherCreatedDomainEventHandler
        : INotificationHandler<WeatherForecastCreatedDomainEvent>
    {
        public async Task Handle(WeatherForecastCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            //TODO: add MassTransit IBus to add an example of message broker implementation
            await Task.Delay(500);
            Console.WriteLine($"A Weather Forecast has been created: {notification.Id}");
        }
    }
}
