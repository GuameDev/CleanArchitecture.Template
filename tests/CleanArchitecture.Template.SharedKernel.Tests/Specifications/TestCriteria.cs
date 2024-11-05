using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using System.Linq.Expressions;
namespace CleanArchitecture.Template.SharedKernel.Tests.Specifications
{
    public class TestCriteria<T> : Criteria<T>
    {
        private readonly Expression<Func<T, bool>> _expression;
        public TestCriteria(Expression<Func<T, bool>> expression)
        {
            _expression = expression;
        }
        public override Expression<Func<T, bool>> ToExpression() => _expression;
    }
}