using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Constants;
using CleanArchitecture.Template.SharedKernel.Entities;
using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using CleanArchitecture.Template.SharedKernel.Specification.Extensions;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification
{
    public class Specification<TEntity> : ISpecification<TEntity>
        where TEntity : Entity
    {
        private readonly List<Expression<Func<TEntity, bool>>> _criteria = new();
        private readonly List<Expression<Func<TEntity, object>>> _includes = new();

        public IReadOnlyCollection<Expression<Func<TEntity, bool>>> Criteria => _criteria.AsReadOnly();
        public IReadOnlyCollection<Expression<Func<TEntity, object>>> Includes => _includes.AsReadOnly();

        public Expression<Func<TEntity, object>>? OrderBy { get; private set; }
        public Expression<Func<TEntity, object>>? OrderByDescending { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; } = false;
        public int? Page { get; private set; }
        public int? PageSize { get; private set; }

        public void AddCriteria(Expression<Func<TEntity, bool>> criteria) => _criteria.Add(criteria);
        public void AddInclude(Expression<Func<TEntity, object>> includeExpression) => _includes.Add(includeExpression);

        public void ApplySorting(Expression<Func<TEntity, object>> orderByExpression, SortDirection sortDirection)
        {
            if (sortDirection == SortDirection.Ascending)
            {
                OrderBy = orderByExpression;
                OrderByDescending = null;
            }
            else
            {
                OrderByDescending = orderByExpression;
                OrderBy = null;
            }
        }

        public void ApplyPaging(int? page, int? pageSize)
        {
            if (page < 1 || pageSize < 1)
                throw new ArgumentException("Page and PageSize must be positive numbers.");

            Page = page ?? PageListConstants.DefaultPage;
            PageSize = pageSize ?? PageListConstants.DefaultPageSize;
            Skip = (Page.Value - 1) * PageSize.Value;
            Take = PageSize.Value;
            IsPagingEnabled = true;
        }

        public ISpecification<TEntity> And(Criteria<TEntity> otherCriteria)
        {
            var newCriteria = otherCriteria.ToExpression();
            if (_criteria.Any())
            {
                var combinedCriteria = _criteria.First().And(newCriteria);
                _criteria.Clear();
                _criteria.Add(combinedCriteria);
            }
            else
            {
                _criteria.Add(newCriteria);
            }
            return this;
        }

        public ISpecification<TEntity> Or(Criteria<TEntity> otherCriteria)
        {
            var newCriteria = otherCriteria.ToExpression();
            if (_criteria.Any())
            {
                var combinedCriteria = _criteria.First().Or(newCriteria);
                _criteria.Clear();
                _criteria.Add(combinedCriteria);
            }
            else
            {
                _criteria.Add(newCriteria);
            }
            return this;
        }

        public ISpecification<TEntity> Not(Criteria<TEntity> criteria)
        {
            var notCriteria = criteria.ToExpression().Not();
            _criteria.Add(notCriteria);
            return this;
        }
        public void ClearCriteria()
        {
            if (_criteria.Any())
            {
                _criteria.Clear();
            }
        }

        public void ClearIncludes()
        {
            if (_includes.Any())
            {
                _includes.Clear();
            }
        }

        public void ClearSorting()
        {
            if (OrderBy != null || OrderByDescending != null)
            {
                OrderBy = null;
                OrderByDescending = null;
            }
        }

    }
}
