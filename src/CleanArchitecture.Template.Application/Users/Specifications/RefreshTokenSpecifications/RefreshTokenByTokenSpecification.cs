using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Application.Users.Specifications.RefreshTokenSpecifications
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
