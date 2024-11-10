using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens.Specifications
{
    public class ActiveRefreshTokensByUserIdSpecification : Specification<RefreshToken>
    {
        public ActiveRefreshTokensByUserIdSpecification(Guid userId)
        {
            //This is an example on to remark that we still can use expressions or strict custom types for our criterias.
            //This: AddCriteria(new ActiveRefreshTokenCriteria()); would be the same as: AddCriteria(x => x.IsRevoked == false);

            AddCriteria(x => x.IsRevoked == false);
            AddCriteria(x => x.UserId == userId);

            //For the current use case that we use this specification, we dont need to make this join,
            //but just say that this would get all the aggregates of the user entity also (Permissions, Roles, Etc..)

            //AddInclude(x => x.User);
        }
    }
}
