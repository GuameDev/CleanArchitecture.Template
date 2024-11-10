using CleanArchitecture.Template.Domain.Users;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Application.Users.Repository
{
    //TODO: implement criteria/specification pattern like:
    //- GetUser(Criteria criteria)
    //- GetUserList(Criteria criteria)

    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<bool> ExistAsync(ISpecification<User> specification);
        Task<User?> GetBySpecificationAsync(ISpecification<User> specification);
        Task<IEnumerable<User>> GetListBySpecificationAsync(ISpecification<User> specification);
    }
}
