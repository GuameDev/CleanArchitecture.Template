using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.SharedKernel.Tests.Specifications
{
    public partial class SpecificationSpecs
    {

        [Fact]
        public void AddCriteria_ShouldAddCriteriaToSpecification()
        {
            // Arrange
            var specification = new Specification<TestEntity>();

            // Act
            specification.AddCriteria(x => x.Id > 0);

            // Assert
            Assert.Single(specification.Criteria);
            Assert.Equal("x => (x.Id > 0)", specification.Criteria.First().ToString());
        }

        [Fact]
        public void AddInclude_ShouldAddIncludeToSpecification()
        {
            // Arrange
            var specification = new Specification<TestEntity>();

            // Act
            specification.AddInclude(x => x.Name);

            // Assert
            Assert.Single(specification.Includes);
            Assert.Equal("x => x.Name", specification.Includes.First().ToString());
        }

        [Fact]
        public void ApplyPaging_ShouldSetPagingValues()
        {
            // Arrange
            var specification = new Specification<TestEntity>();

            // Act
            specification.ApplyPaging(2, 10);

            // Assert
            Assert.True(specification.IsPagingEnabled);
            Assert.Equal(10, specification.Take);
            Assert.Equal(10, specification.Skip);
        }

        [Fact]
        public void ApplySorting_ShouldSetOrderByForAscending()
        {
            // Arrange
            var specification = new Specification<TestEntity>();

            // Act
            specification.ApplySorting(x => x.Name, SortDirection.Ascending);

            // Assert
            Assert.NotNull(specification.OrderBy);
            Assert.Null(specification.OrderByDescending);
            Assert.Equal("x => x.Name", specification.OrderBy.ToString());
        }

        [Fact]
        public void ApplySorting_ShouldSetOrderByDescendingForDescending()
        {
            // Arrange
            var specification = new Specification<TestEntity>();

            // Act
            specification.ApplySorting(x => x.Name, SortDirection.Descending);

            // Assert
            Assert.NotNull(specification.OrderByDescending);
            Assert.Null(specification.OrderBy);
            Assert.Equal("x => x.Name", specification.OrderByDescending.ToString());
        }

        [Fact]
        public void And_ShouldCombineTwoCriteriasWithAnd()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.AddCriteria(x => x.Age > 18);

            // Act
            specification.And(new TestCriteria<TestEntity>(x => x.Name == "John"));

            // Assert
            var combinedCriteria = specification.Criteria.First().Compile();

            // Test data
            var matchingEntity = new TestEntity { Age = 20, Name = "John" };
            var nonMatchingEntity1 = new TestEntity { Age = 16, Name = "John" };
            var nonMatchingEntity2 = new TestEntity { Age = 20, Name = "Doe" };

            Assert.True(combinedCriteria(matchingEntity));
            Assert.False(combinedCriteria(nonMatchingEntity1));
            Assert.False(combinedCriteria(nonMatchingEntity2));
        }

        [Fact]
        public void Or_ShouldCombineTwoCriteriasWithOr()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.AddCriteria(x => x.Age > 18);

            // Act
            specification.Or(new TestCriteria<TestEntity>(x => x.Name == "John"));

            // Assert
            var combinedCriteria = specification.Criteria.First().Compile();

            // Test data
            var matchingEntity1 = new TestEntity { Age = 20, Name = "Doe" };
            var matchingEntity2 = new TestEntity { Age = 16, Name = "John" };
            var nonMatchingEntity = new TestEntity { Age = 16, Name = "Doe" };

            Assert.True(combinedCriteria(matchingEntity1));
            Assert.True(combinedCriteria(matchingEntity2));
            Assert.False(combinedCriteria(nonMatchingEntity));
        }

        [Fact]
        public void Not_ShouldNegateCriteria()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            var criteria = new TestCriteria<TestEntity>(x => x.Age > 18);

            // Act
            specification.Not(criteria);

            // Assert
            Assert.Single(specification.Criteria);
            Assert.Equal("x => Not((x.Age > 18))", specification.Criteria.First().ToString());
        }
    }
}
