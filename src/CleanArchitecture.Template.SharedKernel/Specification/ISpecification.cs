using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification
{
    public interface ISpecification<T>
    {
        // Read-only collection of criteria (filter expressions)
        IReadOnlyCollection<Expression<Func<T, bool>>> Criteria { get; }

        // Read-only collection of expression-based include expressions for eager loading
        IReadOnlyCollection<Expression<Func<T, object>>> Includes { get; }

        // Read-only collection of string-based includes for nested loading
        IReadOnlyCollection<string> IncludeStrings { get; }

        // Read-only collection of string-based then-includes for nested loading
        IReadOnlyDictionary<string, List<string>> ThenIncludeStrings { get; }

        // Sorting expressions
        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDescending { get; }

        // Paging parameters
        int Take { get; }
        int Skip { get; }
        bool IsPagingEnabled { get; }
        int? Page { get; }
        int? PageSize { get; }

        // Methods for adding criteria (It would be the same to use the And method)
        void AddCriteria(Expression<Func<T, bool>> criteria);

        // Methods for sorting and paging
        void ApplySorting(Expression<Func<T, object>> orderByExpression, SortDirection sortDirection);
        void ApplyPaging(int? page, int? pageSize);

        // Method to add include expressions
        void AddInclude(Expression<Func<T, object>> includeExpression);

        // Combine criteria using And, Or, and Not logic
        ISpecification<T> And(Criteria<T> criteria);
        ISpecification<T> Or(Criteria<T> criteria);
        ISpecification<T> Not(Criteria<T> criteria);
    }
}
