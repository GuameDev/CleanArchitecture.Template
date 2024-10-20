using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Domain.Users.Specifications.Criterias
{
    public class UserByEmailCriteria : Criteria<User>
    {
        private readonly string _email;

        public UserByEmailCriteria(string email)
        {
            _email = email;
        }
        public override Expression<Func<User, bool>> ToExpression()
        {
            return user => user.Email.Value == _email;
        }
    }
}
