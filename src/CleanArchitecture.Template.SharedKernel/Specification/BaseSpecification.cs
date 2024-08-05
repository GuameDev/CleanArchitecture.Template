using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        private readonly List<Expression<Func<T, bool>>> _criteria = new();

        public BaseSpecification() { }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            _criteria.Add(criteria);
        }

        public IReadOnlyCollection<Expression<Func<T, bool>>> Criteria => _criteria.AsReadOnly();
        public List<Expression<Func<T, object>>> Includes { get; } = new();
        public Expression<Func<T, object>> OrderBy { get; private set; }
        public Expression<Func<T, object>> OrderByDescending { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool IsPagingEnabled { get; private set; } = false;

        protected void AddCriteria(Expression<Func<T, bool>> criteria)
        {
            _criteria.Add(criteria);
        }

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        //TODO: Maybe have sense to move this: (request.Page.Value - 1) * request.PageSize.Value - to this method
        protected void ApplyPaging(int skip, int take, int page, int pageSize)
        {
            Skip = skip;
            Take = take;
            IsPagingEnabled = true;
            Page = page;
            PageSize = pageSize;
        }
    }
}