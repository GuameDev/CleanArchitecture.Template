using CleanArchitecture.Template.Domain.Users.Aggregates.Roles;
using CleanArchitecture.Template.Domain.Users.Specifications.Criterias;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Domain.Users.Specifications
{
    public class UserByEmailOrUsernameSpecification : Specification<User>
    {

        public UserByEmailOrUsernameSpecification(string email, string username)
        {
            Or(new UserByEmailCriteria(email));
            Or(new UserByUsernameCriteria(username));
            AddInclude(x => x.Roles);
            AddThenInclude(nameof(User.Roles), nameof(Role.Permissions));
        }
        public UserByEmailOrUsernameSpecification(string usernameOrPassword)
        {
            Or(new UserByEmailCriteria(usernameOrPassword));
            Or(new UserByUsernameCriteria(usernameOrPassword));
            AddInclude(nameof(User.Roles));
            AddThenInclude(nameof(User.Roles), nameof(Role.Permissions));
        }
    }
}
