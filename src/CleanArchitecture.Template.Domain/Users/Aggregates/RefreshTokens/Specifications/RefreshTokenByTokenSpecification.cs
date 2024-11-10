using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens.Specifications
{
    public class RefreshTokenByTokenSpecification : Specification<RefreshToken>
    {
        public RefreshTokenByTokenSpecification(string token)
        {
            AddCriteria(refreshToken => refreshToken.Token.Equals(token));
            AddInclude(refreshToken => refreshToken.User);
        }
    }
}
