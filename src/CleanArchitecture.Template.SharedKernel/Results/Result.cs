using CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects.Errors.Base;
using System.Diagnostics.CodeAnalysis;

namespace CleanArchitecture.Template.SharedKernel.Results
{
    public class Result
    {
        public Result(bool isSuccess, Error error)
        {
            if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
                throw new ArgumentException($"Invalid error", nameof(error));

            IsSuccess = isSuccess;
            Error = error;

        }
        public bool IsSuccess { get; set; }
        public bool IsFailure => !IsSuccess;
        public Error Error { get; private set; }

        public static Result Success() => new(true, Error.None);
        public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

        public static Result Failure(Error error) => new(false, error);
        public static Result<TValue> Failure<TValue>(Error error) => new(default, false, error);

        // Combines multiple results into one
        public static Result Combine(params Result[] results)
        {
            foreach (var result in results)
            {
                if (result.IsFailure)
                    return result;
            }
            return Success();
        }

        // Executes a function if the result is successful, otherwise returns the failure
        public Result OnSuccess(Func<Result> func)
        {
            if (IsFailure)
                return this;

            return func();
        }

        // Executes a function with the result's value if successful, otherwise returns the failure
        public Result<T> OnSuccess<T>(Func<T> func)
        {
            if (IsFailure)
                return Failure<T>(Error);

            return Success(func());
        }

    }

    public class Result<TValue> : Result
    {
        private readonly TValue? _value;

        public Result(TValue? value, bool isSuccess, Error error)
            : base(isSuccess, error)
        {
            _value = value;
        }

        [NotNull]
        public TValue Value => IsSuccess
            ? _value!
            : throw new InvalidOperationException($"The value of a failure result cant be accessed");

        public static implicit operator Result<TValue>(TValue? value) =>
            value is not null ? Success(value) : Failure<TValue>(Error.NullValue);

        public static Result<TValue> ValidationFailure(Error error) =>
            new(default, false, error);
    }
}
