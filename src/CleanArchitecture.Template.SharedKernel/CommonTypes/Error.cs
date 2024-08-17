using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;

namespace CleanArchitecture.Template.SharedKernel.CommonTypes
{
    public sealed class Error : ValueObject
    {
        public Error(string code, string description, ErrorType errorType)
        {
            Code = code;
            Description = description;
            Type = errorType;
        }

        public string Code { get; }
        public string Description { get; }
        public ErrorType Type { get; }

        public static implicit operator string(Error error) => error?.Code ?? string.Empty;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return Description;
        }

        public static Error None => new Error("NoneError", "None error message", ErrorType.None);
        public static Error NullValue => new Error("NullValue.Error", "Null value message", ErrorType.NullValue);
        public static Error Validation(string code, string message) => new Error(code, message, ErrorType.Validation);
        public static Error Problem(string code, string message) => new Error(code, message, ErrorType.Problem);
        public static Error NotFound(string code, string message) => new Error(code, message, ErrorType.NotFound);
        public static Error Conflict(string code, string message) => new Error(code, message, ErrorType.Conflict);
    }
}
