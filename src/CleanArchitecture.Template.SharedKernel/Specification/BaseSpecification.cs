using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Constants;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        private readonly List<Expression<Func<T, bool>>> _criteria = new();
        private readonly List<Expression<Func<T, object>>> _includes = new();

        // Properties
        public IReadOnlyCollection<Expression<Func<T, bool>>> Criteria => _criteria.AsReadOnly();
        public IReadOnlyCollection<Expression<Func<T, object>>> Includes => _includes.AsReadOnly();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool IsPagingEnabled { get; private set; } = false;

        // Methods
        protected void AddCriteria(Expression<Func<T, bool>> criteria) => _criteria.Add(criteria);

        protected void AddInclude(Expression<Func<T, object>> includeExpression) => _includes.Add(includeExpression);

        protected void SetOrderBy(Expression<Func<T, object>> orderByExpression) => OrderBy = orderByExpression;

        protected void SetOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression) => OrderByDescending = orderByDescendingExpression;

        // Add sorting logic to the base specification
        protected void ApplySorting(Expression<Func<T, object>> orderByExpression, SortDirection sortDirection)
        {
            if (sortDirection == SortDirection.Ascending)
                SetOrderBy(orderByExpression);
            else
                SetOrderByDescending(orderByExpression);
        }

        // Apply paging
        protected void ApplyPaging(int? page, int? pageSize)
        {
            Page = page ?? PageListConstants.DefaultPage;
            PageSize = pageSize ?? PageListConstants.DefaultPageSize;
            Skip = (Page - 1) * PageSize;
            Take = PageSize;
            IsPagingEnabled = true;
        }

        protected void AddCriteria(params Expression<Func<T, bool>>[] criteria) => _criteria.AddRange(criteria);

        protected void AddIncludes(params Expression<Func<T, object>>[] includes) => _includes.AddRange(includes);
    }
}
