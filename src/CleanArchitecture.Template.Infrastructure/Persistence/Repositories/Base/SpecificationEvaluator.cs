using CleanArchitecture.Template.SharedKernel.Specification;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Template.Infrastructure.Persistence.Repositories.Base
{
    public class SpecificationEvaluator<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
        {
            var query = inputQuery;

            // Apply criteria
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
            // Apply expression-based includes
            foreach (var include in specification.Includes)
            {
                query = query.Include(include);
            }

            // Apply string-based includes
            foreach (var includeString in specification.IncludeStrings)
            {
                query = query.Include(includeString);
            }

            // Apply string-based then-includes
            foreach (var (include, thenIncludes) in specification.ThenIncludeStrings)
            {
                foreach (var thenInclude in thenIncludes)
                {
                    query = query.Include($"{include}.{thenInclude}");
                }
            }

            return query;
        }
    }
}
