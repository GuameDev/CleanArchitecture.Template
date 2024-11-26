
namespace CleanArchitecture.Template.SharedKernel.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<int> CountBySpecificationAsync(Specification.ISpecification<TEntity> specification);
        void Delete(TEntity entity);
        Task DeleteAsync(Guid id);
        void DeleteRange(IEnumerable<TEntity> entities);
        Task<bool> ExistAsync(Specification.ISpecification<TEntity> specification);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<Responses.ListAllResponse<TResponseDTO>> GetAllAsync<TResponseDTO>(System.Linq.Expressions.Expression<Func<TEntity, TResponseDTO>> selector) where TResponseDTO : class;
        Task<TEntity?> GetByIdAsync(Guid id);
        Task<TEntity?> GetBySpecificationAsync(Specification.ISpecification<TEntity> specification);
        Task<IEnumerable<TEntity>> GetListBySpecificationAsync(Specification.ISpecification<TEntity> specification);
        Task<Responses.PageListResponse<TResponseDTO>> GetPaginatedListBySpecificationAsync<TResponseDTO>(Specification.ISpecification<TEntity> specification, System.Linq.Expressions.Expression<Func<TEntity, TResponseDTO>> selector) where TResponseDTO : class;
        void Update(TEntity entity);
    }
}
