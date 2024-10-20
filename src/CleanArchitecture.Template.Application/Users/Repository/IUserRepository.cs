using CleanArchitecture.Template.Domain.Users;

namespace CleanArchitecture.Template.Application.Users.Repository
{
    //TODO: implement criteria/specification pattern like:
    //- GetUser(Criteria criteria)
    //- GetUserList(Criteria criteria)

    public interface IUserRepository
    {
        Task<User?> GetByUsernameAsync(string username);
        Task<User?> GetByEmailAsync(string Email);
        Task AddUserAsync(User user);
        Task<bool> Exist(string username, string email);
        Task<User?> GetById(Guid id);
    }
}
