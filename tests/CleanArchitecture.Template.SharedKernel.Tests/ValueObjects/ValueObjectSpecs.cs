namespace CleanArchitecture.Template.SharedKernel.Tests.ValueObjects
{
    public class ValueObjectSpecs
    {
        private class TestValueObject : ValueObject
        {
            public int Value1 { get; }
            public string Value2 { get; }

            public TestValueObject(int value1, string value2)
            {
                Value1 = value1;
                Value2 = value2;
            }

            protected override IEnumerable<object> GetAtomicValues()
            {
                yield return Value1;
                yield return Value2;
            }
        }

        [Fact]
        public void ValueObject_ShouldBeEqual_WhenValuesAreSame()
        {
            // Arrange
            var firstValueObject = new TestValueObject(1, "Test");
            var secondValueObject = new TestValueObject(1, "Test");

            // Act & Assert
            Assert.Equal(firstValueObject, secondValueObject);
            Assert.True(firstValueObject.Equals(secondValueObject));
            Assert.True(firstValueObject == secondValueObject);
            Assert.Equal(firstValueObject.GetHashCode(), secondValueObject.GetHashCode());
        }

        [Fact]
        public void ValueObject_ShouldNotBeEqual_WhenValuesAreDifferent()
        {
            // Arrange
            var firstValueObject = new TestValueObject(1, "Test");
            var secondValueObject = new TestValueObject(2, "Test");

            // Act & Assert
            Assert.NotEqual(firstValueObject, secondValueObject);
            Assert.False(firstValueObject.Equals(secondValueObject));
            Assert.True(firstValueObject != secondValueObject);
            Assert.NotEqual(firstValueObject.GetHashCode(), secondValueObject.GetHashCode());
        }
        [Fact]
        public void ValueObject_ShouldNotBeEqual_WhenOneIsNull()
        {
            // Arrange
            var firstValueObject = new TestValueObject(1, "Test");
            TestValueObject? secondValueObject = null;

            // Act & Assert
            Assert.False(firstValueObject == secondValueObject);
            Assert.True(firstValueObject != secondValueObject);
            Assert.False(firstValueObject.Equals(secondValueObject));
        }

        [Fact]
        public void ValueObject_ShouldNotBeEqual_WhenDifferentTypes()
        {
            // Arrange
            var firstValueObject = new TestValueObject(1, "Test");
            var secondValueObject = new AnotherTestValueObject(1, "Test");

            // Act & Assert
            Assert.False(firstValueObject.Equals(secondValueObject));
        }

        [Fact]
        public void ValueObject_Equals_ShouldReturnFalse_WhenOtherIsNull()
        {
            // Arrange
            var valueObject = new TestValueObject(1, "Test");

            // Act
            var result = valueObject.Equals(null);

            // Assert
            Assert.False(result);
        }

        private class AnotherTestValueObject : ValueObject
        {
            public int Value1 { get; }
            public string Value2 { get; }

            public AnotherTestValueObject(int value1, string value2)
            {
                Value1 = value1;
                Value2 = value2;
            }

            protected override IEnumerable<object> GetAtomicValues()
            {
                yield return Value1;
                yield return Value2;
            }
        }
    }
}
