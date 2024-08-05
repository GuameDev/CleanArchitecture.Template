
using System.Linq.Expressions;

namespace CleanArchitecture.Template.Application.Base.Specification
{
    public interface ISpecification<T>
    {
        IReadOnlyCollection<Expression<Func<T, bool>>> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }
        int Take { get; }
        int Skip { get; }
        int Page { get; }
        int PageSize { get; }
        bool IsPagingEnabled { get; }
    }
}
