namespace CleanArchitecture.Template.SharedKernel.Tests.Results
{
    using CleanArchitecture.Template.SharedKernel.CommonTypes;
    using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
    using CleanArchitecture.Template.SharedKernel.Results;
    using Xunit;

    public class ResultSpecs
    {
        [Fact]
        public void Success_ShouldReturnSuccessResult()
        {
            // Act
            var result = Result.Success();

            // Assert
            Assert.True(result.IsSuccess);
            Assert.False(result.IsFailure);
            Assert.Equal(Error.None, result.Error);
        }

        [Fact]
        public void Failure_ShouldReturnFailureResult()
        {
            // Arrange
            var error = new Error("TestError", "Test error message", ErrorType.Problem);

            // Act
            var result = Result.Failure(error);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.True(result.IsFailure);
            Assert.Equal(error, result.Error);
        }

        [Fact]
        public void Combine_ShouldReturnFirstFailure_WhenAnyResultFails()
        {
            // Arrange
            var successResult = Result.Success();
            var failureResult = Result.Failure(new Error("TestError", "Test error message", ErrorType.Problem));

            // Act
            var combinedResult = Result.Combine(successResult, failureResult, successResult);

            // Assert
            Assert.False(combinedResult.IsSuccess);
            Assert.Equal(failureResult.Error, combinedResult.Error);
        }

        [Fact]
        public void Combine_ShouldReturnSuccess_WhenAllResultsSucceed()
        {
            // Arrange
            var successResult1 = Result.Success();
            var successResult2 = Result.Success();

            // Act
            var combinedResult = Result.Combine(successResult1, successResult2);

            // Assert
            Assert.True(combinedResult.IsSuccess);
            Assert.Equal(Error.None, combinedResult.Error);
        }

        [Fact]
        public void OnSuccess_ShouldExecuteFunction_WhenResultIsSuccess()
        {
            // Arrange
            var successResult = Result.Success();
            var wasExecuted = false;

            // Act
            var result = successResult.OnSuccess(() =>
            {
                wasExecuted = true;
                return Result.Success();
            });

            // Assert
            Assert.True(result.IsSuccess);
            Assert.True(wasExecuted);
        }

        [Fact]
        public void OnSuccess_ShouldNotExecuteFunction_WhenResultIsFailure()
        {
            // Arrange
            var failureResult = Result.Failure(new Error("TestError", "Test error message", ErrorType.Problem));
            var wasExecuted = false;

            // Act
            var result = failureResult.OnSuccess(() =>
            {
                wasExecuted = true;
                return Result.Success();
            });

            // Assert
            Assert.False(result.IsSuccess);
            Assert.False(wasExecuted);
            Assert.Equal(failureResult.Error, result.Error);
        }

        [Fact]
        public void ResultT_Success_ShouldReturnSuccessResultWithValue()
        {
            // Arrange
            var value = "Test Value";

            // Act
            var result = Result.Success(value);

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(value, result.Value);
        }

        [Fact]
        public void ResultT_Failure_ShouldReturnFailureResultWithError()
        {
            // Arrange
            var error = new Error("TestError", "Test error message", ErrorType.Problem);

            // Act
            var result = Result.Failure<string>(error);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(error, result.Error);
            Assert.Throws<InvalidOperationException>(() => result.Value);
        }

        [Fact]
        public void ResultT_OnSuccess_ShouldReturnSuccessResultWithTransformedValue()
        {
            // Arrange
            var value = "Test Value";
            var result = Result.Success(value);

            // Act
            var transformedResult = result.OnSuccess(() => value.Length);

            // Assert
            Assert.True(transformedResult.IsSuccess);
            Assert.Equal(value.Length, transformedResult.Value);
        }

        [Fact]
        public void ResultT_OnSuccess_ShouldReturnFailureResult_WhenOriginalResultIsFailure()
        {
            // Arrange
            var error = new Error("TestError", "Test error message", ErrorType.Problem);
            var result = Result.Failure<string>(error);

            // Act
            var transformedResult = result.OnSuccess(() => 0);

            // Assert
            Assert.False(transformedResult.IsSuccess);
            Assert.Equal(error, transformedResult.Error);
        }

        [Fact]
        public void ImplicitOperator_ShouldReturnSuccessResult_WhenValueIsNotNull()
        {
            // Arrange
            string value = "Test Value";

            // Act
            Result<string> result = value;

            // Assert
            Assert.True(result.IsSuccess);
            Assert.Equal(value, result.Value);
        }

        [Fact]
        public void ImplicitOperator_ShouldReturnFailureResult_WhenValueIsNull()
        {
            // Arrange
            string value = null!;

            // Act
            Result<string> result = value;

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal(Error.NullValue, result.Error);
        }
    }

}
