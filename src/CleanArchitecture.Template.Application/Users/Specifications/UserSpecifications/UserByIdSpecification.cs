using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Aggregates.Roles;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Application.Users.Specifications.UserSpecifications
{
    public class UserByIdSpecification : Specification<User>
    {
        public UserByIdSpecification(Guid id)
        {
            AddCriteria(user => user.Id == id);
            AddInclude(user => user.Roles);
            AddThenInclude(nameof(User.Roles), nameof(Role.Permissions));
        }
    }
}
