namespace CleanArchitecture.Template.SharedKernel.Entities
{
    public class Entity<Tkey>
    {
        public required Tkey Id { get; set; }
    }
}
