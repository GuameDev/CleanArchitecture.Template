using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification
{
    /// <summary>
    /// Represents a specification for filtering, sorting, paging, and including related data in a query.
    /// </summary>
    public interface ISpecification<T>
    {
        /// <summary>
        /// Gets the collection of filtering criteria as expressions.
        /// </summary>
        IReadOnlyCollection<Expression<Func<T, bool>>> Criteria { get; }

        /// <summary>
        /// Gets the collection of include expressions for eager loading related data.
        /// </summary>
        IReadOnlyCollection<Expression<Func<T, object>>> Includes { get; }

        /// <summary>
        /// Gets the ascending sorting expression, if specified.
        /// </summary>
        Expression<Func<T, object>> OrderBy { get; }

        /// <summary>
        /// Gets the descending sorting expression, if specified.
        /// </summary>
        Expression<Func<T, object>> OrderByDescending { get; }

        /// <summary>
        /// Gets the maximum number of records to return for pagination.
        /// </summary>
        int Take { get; }

        /// <summary>
        /// Gets the number of records to skip for pagination.
        /// </summary>
        int Skip { get; }

        /// <summary>
        /// Indicates whether pagination is enabled.
        /// </summary>
        bool IsPagingEnabled { get; }

        /// <summary>
        /// Gets the current page number for pagination, if specified.
        /// </summary>
        int? Page { get; }

        /// <summary>
        /// Gets the page size for pagination, if specified.
        /// </summary>
        int? PageSize { get; }

        /// <summary>
        /// Adds a new filtering criteria to the specification.
        /// </summary>
        void AddCriteria(Expression<Func<T, bool>> criteria);

        /// <summary>
        /// Adds an include expression for eager loading related data.
        /// </summary>
        void AddInclude(Expression<Func<T, object>> includeExpression);

        /// <summary>
        /// Applies sorting to the specification.
        /// </summary>
        void ApplySorting(Expression<Func<T, object>> orderByExpression, SortDirection sortDirection);

        /// <summary>
        /// Applies pagination settings to the specification.
        /// </summary>
        void ApplyPaging(int? page, int? pageSize);

        /// <summary>
        /// Clears all filtering criteria from the specification.
        /// </summary>
        void ClearCriteria();

        /// <summary>
        /// Clears all include expressions from the specification.
        /// </summary>
        void ClearIncludes();

        /// <summary>
        /// Clears sorting expressions from the specification.
        /// </summary>
        void ClearSorting();

        /// <summary>
        /// Combines an additional criteria with "And" logic.
        /// </summary>
        ISpecification<T> And(Criteria<T> criteria);

        /// <summary>
        /// Combines an additional criteria with "Or" logic.
        /// </summary>
        ISpecification<T> Or(Criteria<T> criteria);

        /// <summary>
        /// Negates a given criteria with "Not" logic.
        /// </summary>
        ISpecification<T> Not(Criteria<T> criteria);
    }
}
