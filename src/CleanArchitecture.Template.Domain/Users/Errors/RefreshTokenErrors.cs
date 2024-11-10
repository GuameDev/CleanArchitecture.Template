using CleanArchitecture.Template.Domain.Users.Constants;
using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.Errors
{
    public static class RefreshTokenErrors
    {
        public static Error RefreshTokenAlreadyAssigned => Error.Problem($"{nameof(User)}.RefreshTokenAlreadyAssigned", "RefreshToken is already assigned to this user.");
        public static Error TokenMinLength => Error.Problem($"{nameof(User)}.RefreshTokenAlreadyAssigned", $"Token must be at least {RefreshTokenConstants.TokenMinLength} characters long.");
    }
}
