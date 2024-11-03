using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Constants;
using CleanArchitecture.Template.SharedKernel.Requests;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.SharedKernel.Tests.Specifications
{
    public partial class SpecificationSpecs
    {

        [Fact]
        public void AddCriteria_ShouldAddCriteriaToSpecification()
        {
            // Arrange
            var specification = new Specification<TestSpecificationEntity>();

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
            var specification = new Specification<TestSpecificationEntity>();

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
            var specification = new Specification<TestSpecificationEntity>();

            // Act
            specification.ApplyPaging(2, 10);

            // Assert
            Assert.True(specification.IsPagingEnabled);
            Assert.Equal(10, specification.Take);
            Assert.Equal(10, specification.Skip);
        }
        [Fact]
        public void ApplyPaging_ShouldSetDefaults_WhenPageAndPageSizeAreNull()
        {
            // Arrange
            var specification = new Specification<TestSpecificationEntity>();

            // Act
            specification.ApplyPaging(null, null);

            // Assert
            Assert.True(specification.IsPagingEnabled);
            Assert.Equal(PageListConstants.DefaultPageSize, specification.Take);
            Assert.Equal((PageListConstants.DefaultPage - 1) * PageListConstants.DefaultPageSize, specification.Skip);
        }
        [Fact]
        public void ApplyPaging_ShouldThrowArgumentException_WhenPageOrPageSizeIsNonPositive()
        {
            // Arrange
            var specification = new Specification<TestSpecificationEntity>();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => specification.ApplyPaging(0, 10));
            Assert.Throws<ArgumentException>(() => specification.ApplyPaging(1, -5));
        }
        [Fact]
        public void ApplySorting_ShouldSetOrderByForAscending()
        {
            // Arrange
            var specification = new Specification<TestSpecificationEntity>();

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
            var specification = new Specification<TestSpecificationEntity>();

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
            var specification = new Specification<TestSpecificationEntity>();
            specification.AddCriteria(x => x.Age > 18);

            // Act
            specification.And(new TestCriteria<TestSpecificationEntity>(x => x.Name == "John"));

            // Assert
            var combinedCriteria = specification.Criteria.First().Compile();

            // Test data
            var matchingEntity = new TestSpecificationEntity { Age = 20, Name = "John" };
            var nonMatchingEntity1 = new TestSpecificationEntity { Age = 16, Name = "John" };
            var nonMatchingEntity2 = new TestSpecificationEntity { Age = 20, Name = "Doe" };

            Assert.True(combinedCriteria(matchingEntity));
            Assert.False(combinedCriteria(nonMatchingEntity1));
            Assert.False(combinedCriteria(nonMatchingEntity2));
        }

        [Fact]
        public void Or_ShouldCombineTwoCriteriasWithOr()
        {
            // Arrange
            var specification = new Specification<TestSpecificationEntity>();
            specification.AddCriteria(x => x.Age > 18);

            // Act
            specification.Or(new TestCriteria<TestSpecificationEntity>(x => x.Name == "John"));

            // Assert
            var combinedCriteria = specification.Criteria.First().Compile();

            // Test data
            var matchingEntity1 = new TestSpecificationEntity { Age = 20, Name = "Doe" };
            var matchingEntity2 = new TestSpecificationEntity { Age = 16, Name = "John" };
            var nonMatchingEntity = new TestSpecificationEntity { Age = 16, Name = "Doe" };

            Assert.True(combinedCriteria(matchingEntity1));
            Assert.True(combinedCriteria(matchingEntity2));
            Assert.False(combinedCriteria(nonMatchingEntity));
        }

        [Fact]
        public void Not_ShouldNegateCriteria()
        {
            // Arrange
            var specification = new Specification<TestSpecificationEntity>();
            var criteria = new TestCriteria<TestSpecificationEntity>(x => x.Age > 18);

            // Act
            specification.Not(criteria);

            // Assert
            Assert.Single(specification.Criteria);
            Assert.Equal("x => Not((x.Age > 18))", specification.Criteria.First().ToString());
        }
        [Fact]
        public void ClearCriteria_ShouldClearAllCriterias()
        {
            // Arrange
            var specification = new Specification<TestSpecificationEntity>();
            specification.AddCriteria(x => x.Age > 18);

            // Act
            specification.ClearCriteria();

            // Assert
            Assert.Empty(specification.Criteria);
        }

        [Fact]
        public void ClearIncludes_ShouldClearAllIncludes()
        {
            // Arrange
            var specification = new Specification<TestSpecificationEntity>();
            specification.AddInclude(x => x.Name);

            // Act
            specification.ClearIncludes();

            // Assert
            Assert.Empty(specification.Includes);
        }

        [Fact]
        public void ClearSorting_ShouldClearOrderByAndOrderByDescending()
        {
            // Arrange
            var specification = new Specification<TestSpecificationEntity>();
            specification.ApplySorting(x => x.Name, SortDirection.Ascending);

            // Act
            specification.ClearSorting();

            // Assert
            Assert.Null(specification.OrderBy);
            Assert.Null(specification.OrderByDescending);
        }
        [Fact]
        public void ApplyDynamicFilters_ShouldAddValidFilterCriteria()
        {
            // Arrange
            var specification = new Specification<TestSpecificationEntity>();
            var filters = new List<DynamicFilterRequest<TestSpecificationEntityProperty>>
            {
                new DynamicFilterRequest<TestSpecificationEntityProperty>
                {
                    Property = TestSpecificationEntityProperty.Name,
                    Operator = FilterOperator.Equals,
                    Value = "John"
                },
                new DynamicFilterRequest<TestSpecificationEntityProperty>
                {
                    Property = TestSpecificationEntityProperty.Age,
                    Operator = FilterOperator.GreaterThan,
                    Value = 18
                }
            };

            // Act
            specification.ApplyDynamicFilters(filters);

            // Assert
            Assert.Equal(2, specification.Criteria.Count);
            Assert.Contains(specification.Criteria, c => c.ToString() == "x => (x.Name == \"John\")");
            Assert.Contains(specification.Criteria, c => c.ToString() == "x => (x.Age > 18)");
        }

        [Fact]
        public void ApplySorting_WithNull_ShouldResetSorting()
        {
            // Arrange
            var specification = new Specification<TestSpecificationEntity>();
            specification.ApplySorting(x => x.Name, SortDirection.Ascending);

            // Act
            specification.ApplySorting(null!, SortDirection.Ascending);

            // Assert
            Assert.Null(specification.OrderBy);
            Assert.Null(specification.OrderByDescending);
        }
    }
}
