using CleanArchitecture.Template.Domain.Users.Aggregates.RefreshTokens;
using CleanArchitecture.Template.SharedKernel.Specification;

namespace CleanArchitecture.Template.Application.Users.Repository
{
    public interface IRefreshTokenRepository
    {
        Task AddAsync(RefreshToken entity);
        Task<RefreshToken?> GetBySpecificationAsync(ISpecification<RefreshToken> specification);
        Task<IEnumerable<RefreshToken>> GetListBySpecificationAsync(ISpecification<RefreshToken> specification);
        void Update(RefreshToken entity);
    }
}
