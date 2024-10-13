﻿using CleanArchitecture.Template.Domain.Users.Errors;
using CleanArchitecture.Template.Domain.Users.ValueObjects;

namespace CleanArchitecture.Template.Domain.Tests.Users.ValueObjects
{
    public class FullNameSpecs
    {
        [Fact]
        public void Create_ShouldReturnSuccess_WhenFullNameIsValid_WithTwoLastNames()
        {
            // Arrange
            var firstName = "John";
            var lastName1 = "Doe";
            var lastName2 = "Smith";

            // Act
            var result = FullName.Create(firstName, lastName1, lastName2);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(firstName, result.Value.FirstName);
            Assert.Equal(lastName1, result.Value.LastName1);
            Assert.Equal(lastName2, result.Value.LastName2);
        }

        [Fact]
        public void Create_ShouldReturnSuccess_WhenFullNameIsValid_WithOneLastName()
        {
            // Arrange
            var firstName = "John";
            var lastName1 = "Doe";

            // Act
            var result = FullName.Create(firstName, lastName1, null);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(firstName, result.Value.FirstName);
            Assert.Equal(lastName1, result.Value.LastName1);
            Assert.Null(result.Value.LastName2);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenFirstNameIsEmpty()
        {
            // Arrange
            var lastName1 = "Doe";

            // Act
            var result = FullName.Create("", lastName1, null);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(FullNameErrors.InvalidFullName, result.Error);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenLastName1IsEmpty()
        {
            // Arrange
            var firstName = "John";

            // Act
            var result = FullName.Create(firstName, "", null);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(FullNameErrors.InvalidFullName, result.Error);
        }

        [Fact]
        public void Create_ShouldReturnFailure_WhenBothFirstNameAndLastName1AreEmpty()
        {
            // Arrange

            // Act
            var result = FullName.Create("", "", null);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(FullNameErrors.InvalidFullName, result.Error);
        }
    }
}
