using CleanArchitecture.Template.Application.Base.Specification;
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

            // Apply sorting
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }

            // Apply includes
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            // Apply paging
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }

            return query;
        }
    }
}