using CleanArchitecture.Template.SharedKernel.Exceptions;
using CleanArchitecture.Template.SharedKernel.Requests;
using CleanArchitecture.Template.SharedKernel.Specification.Extensions;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification.Helpers
{
    /// <summary>
    /// Provides helper methods for creating dynamic filter expressions based on specified filter criteria.
    /// </summary>
    public static class DynamicFilterHelper
    {
        /// <summary>
        /// Creates a dynamic filter expression for the specified filter request.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity to filter.</typeparam>
        /// <typeparam name="TPropertyNameEnum">An enum representing the properties of the entity.</typeparam>
        /// <param name="filter">The filter request containing the property, operator, and value.</param>
        /// <returns>
        /// An expression representing the filter criteria, or null if the value cannot be converted to the target type.
        /// </returns>
        public static Expression<Func<TEntity, bool>>? CreateDynamicFilter<TEntity, TPropertyNameEnum>(DynamicFilterRequest<TPropertyNameEnum> filter)
            where TPropertyNameEnum : Enum
        {
            // Define the parameter for the lambda expression, representing an instance of T (e.g., "x => x.Property == Value").
            var parameter = Expression.Parameter(typeof(TEntity), "x");

            // Get the specified property from the entity using the enum value as the property name.
            var property = Expression.Property(parameter, filter.Property.ToString());

            // Convert the provided filter value to match the type of the property.
            var convertedValue = ConvertValue(filter.Value, property.Type);
            if (convertedValue == null) return null;

            // Create a constant expression for the converted value to use in the comparison.
            var constant = Expression.Constant(convertedValue, property.Type);

            // Build the comparison expression based on the specified operator and property/constant expressions.
            var comparison = BuildComparisonExpression(filter.Operator, property, constant);

            // If a valid comparison expression was created, return it as a lambda expression; otherwise, return null.
            return comparison != null ? Expression.Lambda<Func<TEntity, bool>>(comparison, parameter) : null;
        }

        /// <summary>
        /// Builds a comparison expression based on the specified filter operator.
        /// </summary>
        /// <param name="filterOperator">The operator to use for the comparison (e.g., Equals, GreaterThan).</param>
        /// <param name="property">The property expression representing the entity's property.</param>
        /// <param name="constant">The constant expression representing the filter value.</param>
        /// <returns>An expression representing the comparison operation.</returns>
        private static Expression? BuildComparisonExpression(FilterOperator filterOperator, Expression property, Expression constant) =>
            filterOperator.BuildComparison(property, constant);

        /// <summary>
        /// Converts the provided filter value to match the target property's type.
        /// </summary>
        /// <param name="value">The value to be converted.</param>
        /// <param name="targetType">The target type of the property to match.</param>
        /// <returns>
        /// The converted value as an object if successful, or throws an ArgumentException if conversion fails.
        /// </returns>
        private static object? ConvertValue(string value, Type targetType)
        {
            try
            {
                // Handle special cases for Guid and Enum types.
                if (targetType == typeof(Guid))
                    return Guid.Parse(value.ToString()!);
                if (targetType.IsEnum)
                    return Enum.Parse(targetType, value.ToString());

                // Convert other types to match the target type.
                return Convert.ChangeType(value, targetType);
            }
            catch (Exception ex)
            {
                // Throw a detailed exception if conversion fails.
                throw new FilterValueConversionException(value, targetType, ex);
            }
        }
    }
}
