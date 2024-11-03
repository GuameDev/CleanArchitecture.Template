namespace CleanArchitecture.Template.SharedKernel.Tests.Specifications.Helpers
{
    // Sample entity for testing
    public class TestEntity
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public Guid Id { get; set; }
        public TestEnum EnumProperty { get; set; }
    }
}
