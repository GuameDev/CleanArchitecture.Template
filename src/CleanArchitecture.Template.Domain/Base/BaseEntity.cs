namespace CleanArchitecture.Template.Domain.Base
{
    public class BaseEntity<Tkey>
    {
        public required Tkey Id { get; set; }
    }
}
