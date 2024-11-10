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
        [Fact]
        public void Specification_ShouldHandleEmptyCriteria()
        {
            var specification = new Specification<TestEntity>();
            Assert.Empty(specification.Criteria);
        }
        [Fact]
        public void AddMultipleIncludes_ShouldAddAllIncludes()
        {
            var specification = new Specification<TestEntity>();
            specification.AddInclude(x => x.Name);
            specification.AddInclude(x => x.Age);
            Assert.Equal(2, specification.Includes.Count);
        }
        [Fact]
        public void Not_ShouldCorrectlyInvertSingleCriteria()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.Not(x => x.Name == "John");

            // Act
            var notCriteria = specification.Criteria.First().Compile();

            // Test data
            var matchingEntity = new TestEntity { Name = "Doe" };
            var nonMatchingEntity = new TestEntity { Name = "John" };

            // Assert
            Assert.True(notCriteria(matchingEntity), "Expected entity with Name != 'John' to match the inverted criteria.");
            Assert.False(notCriteria(nonMatchingEntity), "Expected entity with Name == 'John' to not match the inverted criteria.");
        }


        [Fact]
        public void And_ShouldChainMultipleCriteria()
        {
            var specification = new Specification<TestEntity>();
            specification.AddCriteria(x => x.Age > 18);
            specification.And(x => x.Name == "John");
            specification.And(x => x.IsActive);

            var combinedCriteria = specification.Criteria.First().Compile();

            // Test data
            Assert.True(combinedCriteria(new TestEntity { Age = 20, Name = "John", IsActive = true }));
            Assert.False(combinedCriteria(new TestEntity { Age = 20, Name = "John", IsActive = false }));
        }
        // --- Tests for AddCriteria with Expression<Func<TEntity, bool>> ---
        [Fact]
        public void AddCriteria_ShouldAddExpressionCriteriaToSpecification()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            // Act
            specification.AddCriteria(x => x.Age > 18);
            // Assert
            Assert.Single(specification.Criteria);
            Assert.Equal("x => (x.Age > 18)", specification.Criteria.First().ToString());
        }

        // --- Tests for AddCriteria with Criteria<TEntity> ---
        [Fact]
        public void AddCriteria_ShouldAddCustomCriteriaToSpecification()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            // Act
            specification.AddCriteria(new TestCriteria<TestEntity>(x => x.Name == "John"));
            // Assert
            Assert.Single(specification.Criteria);
            Assert.Equal("x => (x.Name == \"John\")", specification.Criteria.First().ToString());
        }

        // --- Tests for And with Expression<Func<TEntity, bool>> ---
        [Fact]
        public void And_ShouldCombineWithExpressionCriteria()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.AddCriteria(x => x.Age > 18);
            // Act
            specification.And(x => x.Name == "John");
            // Assert
            var combinedCriteria = specification.Criteria.First().Compile();
            Assert.True(combinedCriteria(new TestEntity { Age = 20, Name = "John" }));
            Assert.False(combinedCriteria(new TestEntity { Age = 20, Name = "Doe" }));
        }

        // --- Tests for And with Criteria<TEntity> ---
        [Fact]
        public void And_ShouldCombineWithCustomCriteria()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.AddCriteria(x => x.Age > 18);
            // Act
            specification.And(new TestCriteria<TestEntity>(x => x.Name == "John"));
            // Assert
            var combinedCriteria = specification.Criteria.First().Compile();
            Assert.True(combinedCriteria(new TestEntity { Age = 20, Name = "John" }));
            Assert.False(combinedCriteria(new TestEntity { Age = 20, Name = "Doe" }));
        }

        // --- Tests for Or with Expression<Func<TEntity, bool>> ---
        [Fact]
        public void Or_ShouldCombineWithExpressionCriteria()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.AddCriteria(x => x.Age > 18);
            // Act
            specification.Or(x => x.Name == "John");
            // Assert
            var combinedCriteria = specification.Criteria.First().Compile();
            Assert.True(combinedCriteria(new TestEntity { Age = 16, Name = "John" }));
            Assert.True(combinedCriteria(new TestEntity { Age = 20, Name = "Doe" }));
            Assert.False(combinedCriteria(new TestEntity { Age = 16, Name = "Doe" }));
        }

        // --- Tests for Or with Criteria<TEntity> ---
        [Fact]
        public void Or_ShouldCombineWithCustomCriteria()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.AddCriteria(x => x.Age > 18);
            // Act
            specification.Or(new TestCriteria<TestEntity>(x => x.Name == "John"));
            // Assert
            var combinedCriteria = specification.Criteria.First().Compile();
            Assert.True(combinedCriteria(new TestEntity { Age = 16, Name = "John" }));
            Assert.True(combinedCriteria(new TestEntity { Age = 20, Name = "Doe" }));
            Assert.False(combinedCriteria(new TestEntity { Age = 16, Name = "Doe" }));
        }

        // --- Tests for Not with Expression<Func<TEntity, bool>> ---
        [Fact]
        public void Not_ShouldInvertExpressionCriteria()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.Not(x => x.Name == "John");
            // Act
            var notCriteria = specification.Criteria.First().Compile();
            // Assert
            Assert.True(notCriteria(new TestEntity { Name = "Doe" }));
            Assert.False(notCriteria(new TestEntity { Name = "John" }));
        }

        // --- Tests for Not with Criteria<TEntity> ---
        [Fact]
        public void Not_ShouldInvertCustomCriteria()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.Not(new TestCriteria<TestEntity>(x => x.Name == "John"));
            // Act
            var notCriteria = specification.Criteria.First().Compile();
            // Assert
            Assert.True(notCriteria(new TestEntity { Name = "Doe" }));
            Assert.False(notCriteria(new TestEntity { Name = "John" }));
        }

        // --- Test for AddInclude with expression ---
        [Fact]
        public void AddInclude_ShouldAddExpressionIncludeToSpecification()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.AddInclude(x => x.Name);
            // Assert
            Assert.Single(specification.Includes);
            Assert.Equal("x => x.Name", specification.Includes.First().ToString());
        }

        // --- Test for AddInclude with string ---
        [Fact]
        public void AddInclude_ShouldAddStringIncludeToSpecification()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.AddInclude("RelatedEntity");
            // Assert
            Assert.Single(specification.IncludeStrings);
            Assert.Equal("RelatedEntity", specification.IncludeStrings.First());
        }

        // --- Test for AddThenInclude ---
        [Fact]
        public void AddThenInclude_ShouldAddNestedIncludeToSpecification()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.AddThenInclude("ParentEntity", "ChildEntity");
            // Assert
            Assert.Single(specification.ThenIncludeStrings);
            Assert.Contains("ChildEntity", specification.ThenIncludeStrings["ParentEntity"]);
        }

        // --- Tests for ApplyPaging with values ---
        [Fact]
        public void ApplyPaging_ShouldSetPageAndPageSize()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            // Act
            specification.ApplyPaging(1, 5);
            // Assert
            Assert.True(specification.IsPagingEnabled);
            Assert.Equal(5, specification.Take);
            Assert.Equal(0, specification.Skip);
        }

        // --- Tests for ApplySorting with OrderBy ascending ---
        [Fact]
        public void ApplySorting_ShouldSetAscendingOrder()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.ApplySorting(x => x.Name, SortDirection.Ascending);
            // Assert
            Assert.NotNull(specification.OrderBy);
            Assert.Null(specification.OrderByDescending);
            Assert.Equal("x => x.Name", specification.OrderBy.ToString());
        }

        // --- Tests for ApplySorting with OrderBy descending ---
        [Fact]
        public void ApplySorting_ShouldSetDescendingOrder()
        {
            // Arrange
            var specification = new Specification<TestEntity>();
            specification.ApplySorting(x => x.Name, SortDirection.Descending);
            // Assert
            Assert.NotNull(specification.OrderByDescending);
            Assert.Null(specification.OrderBy);
            Assert.Equal("x => x.Name", specification.OrderByDescending.ToString());
        }
    }
}