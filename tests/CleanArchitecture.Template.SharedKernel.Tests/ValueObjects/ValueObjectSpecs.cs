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
            var vo1 = new TestValueObject(1, "Test");
            var vo2 = new TestValueObject(1, "Test");

            // Act & Assert
            Assert.Equal(vo1, vo2);
            Assert.True(vo1.Equals(vo2));
            Assert.True(vo1 == vo2);
            Assert.Equal(vo1.GetHashCode(), vo2.GetHashCode());
        }

        [Fact]
        public void ValueObject_ShouldNotBeEqual_WhenValuesAreDifferent()
        {
            // Arrange
            var vo1 = new TestValueObject(1, "Test");
            var vo2 = new TestValueObject(2, "Test");

            // Act & Assert
            Assert.NotEqual(vo1, vo2);
            Assert.False(vo1.Equals(vo2));
            Assert.True(vo1 != vo2);
            Assert.NotEqual(vo1.GetHashCode(), vo2.GetHashCode());
        }
        [Fact]
        public void ValueObject_ShouldNotBeEqual_WhenOneIsNull()
        {
            // Arrange
            var vo1 = new TestValueObject(1, "Test");
            TestValueObject? vo2 = null;

            // Act & Assert
            Assert.False(vo1 == vo2);
            Assert.True(vo1 != vo2);
            Assert.False(vo1.Equals(vo2));
        }

        [Fact]
        public void ValueObject_ShouldNotBeEqual_WhenDifferentTypes()
        {
            // Arrange
            var vo1 = new TestValueObject(1, "Test");
            var vo2 = new AnotherTestValueObject(1, "Test");

            // Act & Assert
            Assert.False(vo1.Equals(vo2));
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
