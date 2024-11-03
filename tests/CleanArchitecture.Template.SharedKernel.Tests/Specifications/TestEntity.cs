using CleanArchitecture.Template.SharedKernel.Entities;

namespace CleanArchitecture.Template.SharedKernel.Tests.Specifications
{
    public class TestEntity : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }

}
