using CleanArchitecture.Template.Domain.Base;
using CleanArchitecture.Template.SharedKernel.Repository;
using CleanArchitecture.Template.SharedKernel.Responses;
using CleanArchitecture.Template.SharedKernel.Specification;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Base
{
    internal class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<ListAllResponse<TResponseDTO>> GetAllAsync<TResponseDTO>(
            Expression<Func<TEntity, TResponseDTO>> selector) where TResponseDTO : class
        {
            var entities = await _dbSet
                .Select(selector)
                .ToListAsync();

            return new ListAllResponse<TResponseDTO>()
            {
                Elements = entities,
                TotalCount = _dbSet.Count(),
            };
        }
        public async Task<bool> ExistAsync(ISpecification<TEntity> specification)
        {
            var query = SpecificationEvaluator<TEntity>.GetQuery(_dbSet.AsQueryable(), specification);
            return await query.AnyAsync();
        }

        public async Task<TEntity?> GetBySpecificationAsync(ISpecification<TEntity> specification)
        {
            var query = SpecificationEvaluator<TEntity>.GetQuery(_dbSet.AsQueryable(), specification);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<TEntity>> GetListBySpecificationAsync(ISpecification<TEntity> specification)
        {
            var query = SpecificationEvaluator<TEntity>.GetQuery(_dbSet.AsQueryable(), specification);
            return await query.ToListAsync();
        }

        public async Task<PageListResponse<TResponseDTO>> GetPaginatedListBySpecificationAsync<TResponseDTO>(
            ISpecification<TEntity> specification,
            Expression<Func<TEntity, TResponseDTO>> selector) where TResponseDTO : class
        {
            var query = SpecificationEvaluator<TEntity>.GetQuery(_dbSet.AsQueryable(), specification);

            var totalCount = await query.CountAsync();
            var elements = await query
                .Select(selector)
                .ToListAsync();

            return new PageListResponse<TResponseDTO>(
                elements,
                specification.Page,
                specification.PageSize,
                totalCount);
        }

        public async Task<int> CountBySpecificationAsync(ISpecification<TEntity> specification)
        {
            var query = SpecificationEvaluator<TEntity>.GetQuery(_dbSet.AsQueryable(), specification);
            return await query.CountAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _dbSet.Where(x => x.Id == id).ExecuteDeleteAsync();
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
