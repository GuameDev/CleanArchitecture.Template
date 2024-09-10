using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.SharedKernel.Results
{
    public interface IValidationResult
    {
        public static readonly Error ValidationError = new Error(
            "ValidationError",
            "A validation problem occurred.",

            CommonTypes.Enums.ErrorType.Validation);
        Error[] Errors { get; }

    }
}
