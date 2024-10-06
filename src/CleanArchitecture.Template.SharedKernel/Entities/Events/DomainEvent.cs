using MediatR;

namespace CleanArchitecture.Template.SharedKernel.Entities.Events
{
    public record DomainEvent(Guid Id) : INotification;
}
