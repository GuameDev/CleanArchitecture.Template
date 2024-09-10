using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.SharedKernel.Results
{
    public sealed class ValidationResult : Result, IValidationResult
    {
        public ValidationResult(Error[] errors) : base(false, IValidationResult.ValidationError)
        {
        }

        public Error[] Errors { get; }
        public static ValidationResult WithErrors(Error[] errors) => new(errors);
    }


}
