using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification.Extensions
{
    public static class ExpressionExtensions
    {
        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return CombineExpressions(first, second, Expression.OrElse);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> first, Expression<Func<T, bool>> second)
        {
            return CombineExpressions(first, second, Expression.AndAlso);
        }

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expression)
        {
            var parameter = expression.Parameters[0];
            var body = Expression.Not(expression.Body);

            return Expression.Lambda<Func<T, bool>>(body, parameter);
        }

        private static Expression<Func<T, bool>> CombineExpressions<T>(Expression<Func<T, bool>> first, Expression<Func<T, bool>> second, Func<Expression, Expression, BinaryExpression> combiner)
        {
            var parameter = Expression.Parameter(typeof(T));

            // Invoke both expressions with the same parameter
            var firstBody = Expression.Invoke(first, parameter);
            var secondBody = Expression.Invoke(second, parameter);

            var combinedBody = combiner(firstBody, secondBody);

            return Expression.Lambda<Func<T, bool>>(combinedBody, parameter);
        }
    }
}
