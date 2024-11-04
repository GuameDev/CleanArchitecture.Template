using CleanArchitecture.Template.SharedKernel.Requests;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification.Extensions
{
    public static class FilterOperatorExtensions
    {
        public static Expression BuildComparison(this FilterOperator filterOperator, Expression property, Expression constant) =>
            filterOperator switch
            {
                FilterOperator.Equals => Expression.Equal(property, constant),
                FilterOperator.GreaterThan => Expression.GreaterThan(property, constant),
                FilterOperator.LessThan => Expression.LessThan(property, constant),
                FilterOperator.GreaterThanOrEqual => Expression.GreaterThanOrEqual(property, constant),
                FilterOperator.LessThanOrEqual => Expression.LessThanOrEqual(property, constant),
                FilterOperator.Contains => Expression.Call(property, typeof(string).GetMethod("Contains", [typeof(string)])!, constant),
                _ => throw new NotSupportedException($"Unsupported filter operator: {filterOperator}")
            };
    }
}
