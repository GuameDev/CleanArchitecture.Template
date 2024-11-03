using CleanArchitecture.Template.SharedKernel.Entities;

namespace CleanArchitecture.Template.SharedKernel.Tests.Specifications
{
    public class TestSpecificationEntity : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }

}
