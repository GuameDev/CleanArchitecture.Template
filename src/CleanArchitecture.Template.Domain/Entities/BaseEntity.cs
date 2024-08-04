namespace CleanArchitecture.Template.Domain.Entities
{
    public class BaseEntity<Tkey>
    {
        public required Tkey Id { get; set; }
    }
}
