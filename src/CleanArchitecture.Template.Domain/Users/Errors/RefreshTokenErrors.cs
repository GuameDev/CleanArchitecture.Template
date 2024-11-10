using CleanArchitecture.Template.SharedKernel.CommonTypes;

namespace CleanArchitecture.Template.Domain.Users.Errors
{
    public static class RefreshTokenErrors
    {
        public static Error RefreshTokenAlreadyAssigned => Error.Problem($"{nameof(User)}.RefreshTokenAlreadyAssigned", "RefreshToken is already assigned to this user.");
    }
}
