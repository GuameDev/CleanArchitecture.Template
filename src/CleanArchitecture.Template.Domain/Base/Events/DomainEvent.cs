using MediatR;

namespace CleanArchitecture.Template.Domain.Base.Events
{
    public record DomainEvent(Guid Id) : INotification;
}
