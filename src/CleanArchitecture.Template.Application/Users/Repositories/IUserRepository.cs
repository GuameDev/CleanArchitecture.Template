using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.SharedKernel.Repository;

namespace CleanArchitecture.Template.Application.Users.Repositories
{
    //TODO: implement criteria/specification pattern like:
    //- GetUser(Criteria criteria)
    //- GetUserList(Criteria criteria)

    public interface IUserRepository : IRepository<User>
    {
    }
}
