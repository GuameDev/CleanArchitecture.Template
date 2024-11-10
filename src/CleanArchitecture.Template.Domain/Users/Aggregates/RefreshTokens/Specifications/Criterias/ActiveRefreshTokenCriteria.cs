using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens.Specifications.Criterias
{
    internal class ActiveRefreshTokenCriteria : Criteria<RefreshToken>
    {
        public override Expression<Func<RefreshToken, bool>> ToExpression()
        {
            return refreshToken => !refreshToken.IsRevoked;
        }
    }
}
