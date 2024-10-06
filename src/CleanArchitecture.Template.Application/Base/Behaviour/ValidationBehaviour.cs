using CleanArchitecture.Template.SharedKernel.CommonTypes;
using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Results;
using FluentValidation;
using MediatR;

namespace CleanArchitecture.Template.Application.Base.Behaviour
{
    public class ValidationBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : Result
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // If no validators found, proceed to next in the pipeline
            if (!_validators.Any())
                return await next();

            //Exectue the validation and project possible validation errors into Error
            Error[] errors = _validators
                .Select(validator => validator.Validate(request))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure is not null)
                .Select(failure => new Error(
                    failure.PropertyName,
                    failure.ErrorMessage,
                    ErrorType.Validation))
                .Distinct()
                .ToArray();

            if (errors.Any())
                return CreateValidationFailureResult<TResponse>(errors);

            return await next();
        }

        private static TResult CreateValidationFailureResult<TResult>(Error[] errors)
            where TResult : Result
        {
            if (typeof(TResult).IsGenericType && typeof(TResult).GetGenericTypeDefinition() == typeof(Result<>))
            {
                var resultType = typeof(TResult).GenericTypeArguments[0];
                var validationResultType = typeof(ValidationResult<>).MakeGenericType(resultType);

                // Create an instance of ValidationResult<T> using the constructor with the Error[] parameter
                var validationResult = Activator.CreateInstance(validationResultType, [default, false, errors]);

                return (TResult)validationResult!;
            }

            // For non-generic Result type (e.g., Result without type parameter)
            if (typeof(TResult) == typeof(Result))
            {
                return (TResult)(object)ValidationResult.WithErrors(errors);
            }

            throw new InvalidOperationException($"Unable to create validation failure result for type {typeof(TResult).FullName}.");
        }






    }
}
