using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification.Criterias
{
    public abstract class Criteria<T>
    {
        public abstract Expression<Func<T, bool>> ToExpression();
    }
}
