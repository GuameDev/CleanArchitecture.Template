using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.SharedKernel.Results
{
    public sealed class ValidationResult<TValue> : Result<TValue>, IValidationResult
    {
        public ValidationResult(Error[] errors) : base(default, false, IValidationResult.ValidationError)
        {
        }

        public Error[] Errors { get; }
        public static ValidationResult WithErrors(Error[] errors) => new(errors);
    }
}
