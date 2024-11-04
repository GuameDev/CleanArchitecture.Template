using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Entities;
using CleanArchitecture.Template.SharedKernel.Requests;
using CleanArchitecture.Template.SharedKernel.Specification.Helpers;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification.DynamicSpecifications
{
    /// <summary>
    /// A flexible specification class that supports dynamic filters, sorting, and pagination without enforcing enums.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity to apply the specification on.</typeparam>
    /// <typeparam name="TPropertyNameEnum">The enum that contains the property names of the entity</typeparam>
    public class DynamicSpecification<TEntity, TPropertyNameEnum> : Specification<TEntity>
        where TEntity : Entity
        where TPropertyNameEnum : Enum

    {

        /// <summary>
        ///  Applies dynamic filters to the specification based on provided filter requests
        /// </summary>
        /// <param name="filters"></param>
        public void ApplyDynamicFilters(IEnumerable<DynamicFilterRequest<TPropertyNameEnum>> filters)
        {
            foreach (var filter in filters)
            {
                var criteria = DynamicFilterHelper.CreateDynamicFilter<TEntity, TPropertyNameEnum>(filter);
                if (criteria != null)
                {
                    AddCriteria(criteria);
                }
            }
        }

        /// <summary>
        /// Applies sorting to the specification based on a property name string and a sort direction.
        /// </summary>
        /// <param name="propertyName">The name of the property to sort by.</param>
        /// <param name="sortDirection">The direction for sorting (Ascending or Descending).</param>
        public void ApplySorting(TPropertyNameEnum propertyName, SortDirection sortDirection)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "x");
            var property = Expression.Property(parameter, propertyName.ToString());
            var orderByExpression = Expression.Lambda<Func<TEntity, object>>(Expression.Convert(property, typeof(object)), parameter);

            base.ApplySorting(orderByExpression, sortDirection);
        }
    }
}
