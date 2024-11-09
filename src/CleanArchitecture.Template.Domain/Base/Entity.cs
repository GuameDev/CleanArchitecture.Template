using CleanArchitecture.Template.Domain.Base.Events;

namespace CleanArchitecture.Template.Domain.Base
{
    public class Entity
    {
        private List<DomainEvent> _domainEvents { get; set; } = new List<DomainEvent>();
        public ICollection<DomainEvent> DomainEvents => _domainEvents;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        protected void Raise(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

    }
}