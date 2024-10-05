using CleanArchitecture.Template.SharedKernel.Specification;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Base
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            // Apply criterias
            foreach (var criteria in specification.Criteria)
            {
                query = query.Where(criteria);
            }

            query = ApplySorting(query, specification);

            query = ApplyIncludes(query, specification);

            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            return query;
        }

        private static IQueryable<TEntity> ApplySorting(IQueryable<TEntity> query, ISpecification<TEntity> specification)
        {
            if (specification.OrderBy != null)
            {
                return query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                return query.OrderByDescending(specification.OrderByDescending);
            }

            return query;
        }

        private static IQueryable<TEntity> ApplyIncludes(IQueryable<TEntity> query, ISpecification<TEntity> specification)
        {
            foreach (var include in specification.Includes)
            {
                query = query.Include(include);
            }

            return query;
        }
    }
}
