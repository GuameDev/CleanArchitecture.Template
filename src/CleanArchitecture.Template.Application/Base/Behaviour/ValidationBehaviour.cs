using CleanArchitecture.Template.SharedKernel.CommonTypes;
using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Results;
using FluentValidation;
using MediatR;

namespace CleanArchitecture.Template.Application.Base.Behaviour
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
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

            var context = new ValidationContext<TRequest>(request);

            // Execute all the validators
            var validationResults = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (validationResults.Any())
            {
                // If there are validation errors, convert them to `Error` and return failure result
                var validationErrors = validationResults.Select(failure => new Error(
                    failure.PropertyName,
                    failure.ErrorMessage,
                    ErrorType.Validation)).ToArray();

                // Return failure with all validation errors
                return CreateValidationFailureResult(validationErrors);
            }

            // Proceed to the next behavior in the pipeline if no validation errors
            return await next();
        }

        private static TResponse CreateValidationFailureResult(Error[] errors)
        {
            if (typeof(TResponse) == typeof(Result))
            {
                return (Result.Failure(errors.First()) as TResponse)!; // Single error as TResponse if it's a basic result
            }

            var genericResultType = typeof(TResponse).GetGenericTypeDefinition().MakeGenericType(typeof(TResponse).GenericTypeArguments[0]);
            var resultInstance = Activator.CreateInstance(genericResultType, default, false, errors.First())!;
            return (TResponse)resultInstance;
        }
    }
}
