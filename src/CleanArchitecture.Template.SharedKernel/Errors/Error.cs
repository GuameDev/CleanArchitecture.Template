using CleanArchitecture.Template.SharedKernel.CommonTypes.ValueObjects;

namespace CleanArchitecture.Template.SharedKernel.Errors
{
    public sealed class Error : ValueObject
    {
        public Error(string code, string message)
        {
            Code = code;
            Message = message;
        }

        public string Code { get; }
        public string Message { get; }

        public static implicit operator string(Error error) => error?.Code ?? string.Empty;

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Code;
            yield return Message;
        }

        public static Error None => new Error(string.Empty, string.Empty);
        public static Error NullValue => new Error(null, null);
    }
}
