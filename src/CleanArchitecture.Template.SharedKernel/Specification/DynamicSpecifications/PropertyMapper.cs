using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification.DynamicSpecifications
{
    public static class PropertyMapper<T, TPropertyEnum> where TPropertyEnum : Enum
    {
        private static readonly Dictionary<TPropertyEnum, Expression<Func<T, object>>> PropertyMap = new();

        public static void RegisterMapping(TPropertyEnum propertyName, Expression<Func<T, object>> expression)
        {
            PropertyMap[propertyName] = expression;
        }

        public static Expression<Func<T, object>> GetPropertyExpression(TPropertyEnum propertyName)
        {
            if (!PropertyMap.TryGetValue(propertyName, out var expression))
                throw new ArgumentException($"No mapping found for {propertyName} in {typeof(T).Name}.");

            return expression;
        }
    }
}
