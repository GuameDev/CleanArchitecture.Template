using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.Domain.Users.Aggregates.Roles;
using CleanArchitecture.Template.Domain.Users.Criterias;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Application.Users.Specifications.UserSpecifications
{
    public class UserByEmailOrUsernameSpecification : Specification<User>
    {

        public UserByEmailOrUsernameSpecification(string email, string username)
        {
            AddCriteria(new UserByEmailCriteria(email));
            Or(new UserByUsernameCriteria(username));
            AddInclude(x => x.Roles);
            AddThenInclude(nameof(User.Roles), nameof(Role.Permissions));
        }
        public UserByEmailOrUsernameSpecification(string usernameOrPassword)
        {
            AddCriteria(new UserByEmailCriteria(usernameOrPassword));
            Or(new UserByUsernameCriteria(usernameOrPassword));
            AddInclude(nameof(User.Roles));
            AddThenInclude(nameof(User.Roles), nameof(Role.Permissions));
        }
    }
}
