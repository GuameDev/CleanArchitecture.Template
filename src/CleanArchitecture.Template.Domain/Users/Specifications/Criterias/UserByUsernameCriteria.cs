using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Domain.Users.Specifications.Criterias
{
    public class UserByUsernameCriteria : Criteria<User>
    {
        private readonly string _username;

        public UserByUsernameCriteria(string username)
        {
            _username = username;
        }
        public override Expression<Func<User, bool>> ToExpression()
        {
            return user => user.Username.Value == _username;
        }
    }
}
