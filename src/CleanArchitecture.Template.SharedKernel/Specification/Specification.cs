using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Constants;
using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using CleanArchitecture.Template.SharedKernel.Specification.Extensions;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification
{
    public class Specification<T> : ISpecification<T>
    {
        private readonly List<Expression<Func<T, bool>>> _criteria = new();
        private readonly List<Expression<Func<T, object>>> _includes = new();

        public IReadOnlyCollection<Expression<Func<T, bool>>> Criteria => _criteria.AsReadOnly();
        public IReadOnlyCollection<Expression<Func<T, object>>> Includes => _includes.AsReadOnly();

        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; } = false;
        public int? Page { get; private set; }
        public int? PageSize { get; private set; }

        // Add individual criteria
        public void AddCriteria(Expression<Func<T, bool>> criteria)
        {
            _criteria.Add(criteria);
        }

        // Add include for eager loading
        public void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            _includes.Add(includeExpression);
        }

        // Apply sorting
        public void ApplySorting(Expression<Func<T, object>> orderByExpression, SortDirection sortDirection)
        {
            if (sortDirection == SortDirection.Ascending)
                OrderBy = orderByExpression;
            else
                OrderByDescending = orderByExpression;
        }

        // Apply paging
        public void ApplyPaging(int? page, int? pageSize)
        {
            Page = page;
            PageSize = pageSize;
            Skip = ((page ?? PageListConstants.DefaultPage) - 1) * (pageSize ?? PageListConstants.DefaultPageSize);
            Take = pageSize ?? PageListConstants.DefaultPageSize;
            IsPagingEnabled = true;
        }

        // Combine criteria using And, Or, and Not methods
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
    }
}
