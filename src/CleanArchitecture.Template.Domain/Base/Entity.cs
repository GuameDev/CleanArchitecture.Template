using CleanArchitecture.Template.Domain.Base.Events;

namespace CleanArchitecture.Template.Domain.Base
{
    public class Entity
    {
        private List<DomainEvent> _domainEvents { get; set; } = new List<DomainEvent>();
        public ICollection<DomainEvent> DomainEvents => _domainEvents;

        //All the entities will have a GUID as Id, this could be configurable with making Entity<TId>
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public byte[] RowVersion { get; set; }
        protected void Raise(DomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
    }
}