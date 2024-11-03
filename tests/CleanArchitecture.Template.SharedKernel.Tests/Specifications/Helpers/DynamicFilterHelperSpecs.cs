using CleanArchitecture.Template.SharedKernel.Exceptions;
using CleanArchitecture.Template.SharedKernel.Requests;
using CleanArchitecture.Template.SharedKernel.Specification.Helpers;

namespace CleanArchitecture.Template.SharedKernel.Tests.Specifications.Helpers
{
    public class DynamicFilterHelperSpecs
    {
        [Fact]
        public void CreateDynamicFilter_ShouldGenerateEqualExpression()
        {
            // Arrange
            var filter = new DynamicFilterRequest<TestEntityProperty>
            {
                Property = TestEntityProperty.Name,
                Operator = FilterOperator.Equals,
                Value = "John"
            };

            // Act
            var expression = DynamicFilterHelper.CreateDynamicFilter<TestEntity, TestEntityProperty>(filter);

            // Assert
            Assert.NotNull(expression);
            Assert.Equal("x => (x.Name == \"John\")", expression.ToString());
        }

        [Fact]
        public void CreateDynamicFilter_ShouldGenerateGreaterThanExpression()
        {
            // Arrange
            var filter = new DynamicFilterRequest<TestEntityProperty>
            {
                Property = TestEntityProperty.Age,
                Operator = FilterOperator.GreaterThan,
                Value = 18
            };

            // Act
            var expression = DynamicFilterHelper.CreateDynamicFilter<TestEntity, TestEntityProperty>(filter);

            // Assert
            Assert.NotNull(expression);
            Assert.Equal("x => (x.Age > 18)", expression.ToString());
        }

        [Fact]
        public void CreateDynamicFilter_ShouldGenerateContainsExpression()
        {
            // Arrange
            var filter = new DynamicFilterRequest<TestEntityProperty>
            {
                Property = TestEntityProperty.Name,
                Operator = FilterOperator.Contains,
                Value = "John"
            };

            // Act
            var expression = DynamicFilterHelper.CreateDynamicFilter<TestEntity, TestEntityProperty>(filter);

            // Assert
            Assert.NotNull(expression);
            Assert.Equal("x => x.Name.Contains(\"John\")", expression.ToString());
        }

        [Fact]
        public void CreateDynamicFilter_ShouldThrowFilterValueConversionException_WhenConvertValueFails()
        {
            // Arrange
            var filter = new DynamicFilterRequest<TestEntityProperty>
            {
                Property = TestEntityProperty.Age,
                Operator = FilterOperator.Equals,
                Value = "InvalidInteger" // Non-convertible to int
            };

            // Act & Assert
            var exception = Assert.Throws<FilterValueConversionException>(() =>
                DynamicFilterHelper.CreateDynamicFilter<TestEntity, TestEntityProperty>(filter));

            // Verify that the exception message contains expected information
            Assert.Contains("Failed to convert value 'InvalidInteger' to target type", exception.Message);
        }


        [Fact]
        public void CreateDynamicFilter_ShouldSupportGuidConversion()
        {
            // Arrange
            var guidValue = Guid.NewGuid();
            var filter = new DynamicFilterRequest<TestEntityProperty>
            {
                Property = TestEntityProperty.Id,
                Operator = FilterOperator.Equals,
                Value = guidValue.ToString()
            };

            // Act
            var expression = DynamicFilterHelper.CreateDynamicFilter<TestEntity, TestEntityProperty>(filter);

            // Assert
            Assert.NotNull(expression);
            Assert.Equal($"x => (x.Id == {guidValue})", expression.ToString());
        }

        [Fact]
        public void CreateDynamicFilter_ShouldSupportEnumConversion()
        {
            // Arrange
            var filter = new DynamicFilterRequest<TestEntityProperty>
            {
                Property = TestEntityProperty.EnumProperty,
                Operator = FilterOperator.Equals,
                Value = "ValueA"
            };

            // Act
            var expression = DynamicFilterHelper.CreateDynamicFilter<TestEntity, TestEntityProperty>(filter);

            // Assert
            Assert.NotNull(expression);
            Assert.Equal("x => (x.EnumProperty == ValueA)", expression.ToString());
        }

        [Fact]
        public void ConvertValue_ShouldThrowFilterValueConversionException_WhenConversionFails()
        {
            // Arrange
            var filter = new DynamicFilterRequest<TestEntityProperty>
            {
                Property = TestEntityProperty.EnumProperty,
                Operator = FilterOperator.Equals,
                Value = "InvalidEnumValue" // Invalid enum value
            };

            // Act & Assert
            var exception = Assert.Throws<FilterValueConversionException>(() =>
                DynamicFilterHelper.CreateDynamicFilter<TestEntity, TestEntityProperty>(filter));
            Assert.Contains("Failed to convert value", exception.Message);
        }

    }
}