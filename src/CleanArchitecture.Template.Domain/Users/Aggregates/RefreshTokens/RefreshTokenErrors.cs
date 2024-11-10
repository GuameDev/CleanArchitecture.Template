using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens
{
    public static class RefreshTokenErrors
    {
        public static Error RefreshTokenAlreadyAssigned => Error.Problem($"{nameof(User)}.RefreshTokenAlreadyAssigned", "RefreshToken is already assigned to this user.");
        public static Error TokenMinLength => Error.Problem($"{nameof(User)}.RefreshTokenAlreadyAssigned", $"Token must be at least {RefreshTokenConstants.TokenMinLength} characters long.");
        public static Error TokenInvalidOrExpired => Error.Conflict($"{nameof(RefreshToken)}.InvalidOrExpiredToken", $"This token is not valid or its expired");
    }
}
