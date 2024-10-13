using CleanArchitecture.Template.SharedKernel.Entities.Events;

namespace CleanArchitecture.Template.SharedKernel.Entities
{
    public class Entity
    {
        private List<DomainEvent> _domainEvents { get; set; } = new List<DomainEvent>();
        public ICollection<DomainEvent> DomainEvents => _domainEvents;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        protected void Raise(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

    }
}