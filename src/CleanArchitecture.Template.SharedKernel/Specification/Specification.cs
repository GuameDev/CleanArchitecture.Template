using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Constants;
using CleanArchitecture.Template.SharedKernel.Requests;
using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using CleanArchitecture.Template.SharedKernel.Specification.Extensions;
using CleanArchitecture.Template.SharedKernel.Specification.Helpers;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification
{
    public class Specification<T> : ISpecification<T>
    {
        private readonly List<Expression<Func<T, bool>>> _criteria = new();
        private readonly List<Expression<Func<T, object>>> _includes = new();

        public IReadOnlyCollection<Expression<Func<T, bool>>> Criteria => _criteria.AsReadOnly();
        public IReadOnlyCollection<Expression<Func<T, object>>> Includes => _includes.AsReadOnly();

        public Expression<Func<T, object>>? OrderBy { get; private set; }
        public Expression<Func<T, object>>? OrderByDescending { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; } = false;

        // Default values for Page and PageSize
        public int? Page { get; private set; }
        public int? PageSize { get; private set; }

        public void AddCriteria(Expression<Func<T, bool>> criteria) => _criteria.Add(criteria);
        public void AddInclude(Expression<Func<T, object>> includeExpression) => _includes.Add(includeExpression);

        public void ApplySorting(Expression<Func<T, object>> orderByExpression, SortDirection sortDirection)
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

        public void ApplyDynamicFilters<TPropertyNameEnum>(IEnumerable<DynamicFilterRequest<TPropertyNameEnum>> filters) where TPropertyNameEnum : Enum
        {
            foreach (var filter in filters)
            {
                var criteria = DynamicFilterHelper.CreateDynamicFilter<T, TPropertyNameEnum>(filter);
                if (criteria != null)
                {
                    AddCriteria(criteria);
                }
            }
        }

        public ISpecification<T> And(Criteria<T> otherCriteria)
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

        public ISpecification<T> Or(Criteria<T> otherCriteria)
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

        public ISpecification<T> Not(Criteria<T> criteria)
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
