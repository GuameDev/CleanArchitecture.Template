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
        }
        public UserByEmailOrUsernameSpecification(string usernameOrPassword)
        {
            Or(new UserByEmailCriteria(usernameOrPassword));
            Or(new UserByUsernameCriteria(usernameOrPassword));
        }
    }
}
