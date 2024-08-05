﻿using CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects.Errors.Base;
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
