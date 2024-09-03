using CleanArchitecture.Template.SharedKernel.CommonTypes;
using CleanArchitecture.Template.SharedKernel.Results;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace CleanArchitecture.Template.Application.Base.Behaviour
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
           where TRequest : IRequest<TResponse>
           where TResponse : IResult, new()
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidationBehavior(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Length == 0)
                return await next();

            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

            if (failures.Count == 0)
            {
                return await next();
            }

            var errors = string.Join(", ", failures.Select(f => f.ErrorMessage));
            var response = new TResponse();
            response = Result.Failure<TResponse>(Error.RequestValidation(errors)).Value;
            return response;
        }
    }
}
