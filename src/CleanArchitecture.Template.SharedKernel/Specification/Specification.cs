using CleanArchitecture.Template.SharedKernel.CommonTypes.Enums;
using CleanArchitecture.Template.SharedKernel.Constants;
using CleanArchitecture.Template.SharedKernel.Specification.Criterias;
using CleanArchitecture.Template.SharedKernel.Specification.Extensions;
using System.Linq.Expressions;

namespace CleanArchitecture.Template.SharedKernel.Specification
{
    //TODO: Is it worth it to reference the domain layer only to enhance the TEntity to be Entity type?
    //TODO: Refactor this class to separace the behaviour (Or.Not,And,AddCriteria,Etc..) into smaller pieces for testing purposes
    public class Specification<TEntity> : ISpecification<TEntity> where TEntity : class
    {
        private readonly List<Expression<Func<TEntity, bool>>> _criteria = new();
        private readonly List<Expression<Func<TEntity, object>>> _includes = new();
        private readonly List<string> _includeStrings = new();
        private readonly Dictionary<string, List<string>> _thenIncludeStrings = new();

        public IReadOnlyCollection<Expression<Func<TEntity, bool>>> Criteria => _criteria.AsReadOnly();
        public IReadOnlyCollection<Expression<Func<TEntity, object>>> Includes => _includes.AsReadOnly();
        public IReadOnlyCollection<string> IncludeStrings => _includeStrings.AsReadOnly();
        public IReadOnlyDictionary<string, List<string>> ThenIncludeStrings => _thenIncludeStrings;

        public Expression<Func<TEntity, object>> OrderBy { get; private set; }
        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; }
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPagingEnabled { get; private set; } = false;
        public int? Page { get; private set; }
        public int? PageSize { get; private set; }

        // Add individual criteria
        public void AddCriteria(Expression<Func<TEntity, bool>> criteria)
        {
            _criteria.Add(criteria);
        }
        public void AddCriteria(Criteria<TEntity> criteria)
        {
            _criteria.Add(criteria.ToExpression());
        }

        // Add include for eager loading
        public void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            if (!_includes.Contains(includeExpression))
            {
                _includes.Add(includeExpression);
            }
        }

        // Add include for eager loading
        public void AddInclude(string includeString)
        {
            if (!_includeStrings.Contains(includeString))
            {
                _includeStrings.Add(includeString);
            }
        }

        // Add then-include for nested loading
        public void AddThenInclude(string include, string thenInclude)
        {
            if (!_thenIncludeStrings.ContainsKey(include))
            {
                _thenIncludeStrings[include] = new List<string>();
            }

            if (!_thenIncludeStrings[include].Contains(thenInclude))
            {
                _thenIncludeStrings[include].Add(thenInclude);
            }
        }


        // Apply sorting
        public void ApplySorting(Expression<Func<TEntity, object>> orderByExpression, SortDirection sortDirection)
        {
            if (sortDirection == SortDirection.Ascending)
                OrderBy = orderByExpression;
            else
                OrderByDescending = orderByExpression;
        }

        // Apply paging
        public void ApplyPaging(int? page, int? pageSize)
        {
            page ??= PageListConstants.DefaultPage;
            pageSize ??= PageListConstants.DefaultPageSize;

            Page = page;
            PageSize = pageSize;
            Skip = (page.Value - 1) * pageSize.Value;
            Take = pageSize.Value;
            IsPagingEnabled = true;
        }

        // Combine criteria using And, Or, and Not methods
        public ISpecification<TEntity> And(Criteria<TEntity> otherCriteria)
        {
            var newCriteria = otherCriteria.ToExpression();
            if (_criteria.Any())
            {
                var combinedCriteria = _criteria.First().And(newCriteria);
                _criteria.Clear();
                _criteria.Add(combinedCriteria);
            }
            else
            {
                _criteria.Add(newCriteria);
            }
            return this;
        }

        public ISpecification<TEntity> Or(Criteria<TEntity> otherCriteria)
        {
            var newCriteria = otherCriteria.ToExpression();
            if (_criteria.Any())
            {
                var combinedCriteria = _criteria.First().Or(newCriteria);
                _criteria.Clear();
                _criteria.Add(combinedCriteria);
            }
            else
            {
                _criteria.Add(newCriteria);
            }
            return this;
        }

        public ISpecification<TEntity> Not(Criteria<TEntity> criteria)
        {
            var notCriteria = criteria.ToExpression().Not();
            _criteria.Add(notCriteria);
            return this;
        }

        // Combine criteria using And, Or, and Not methods
        public ISpecification<TEntity> And(Expression<Func<TEntity, bool>> otherCriteria)
        {
            var newCriteria = otherCriteria;
            if (_criteria.Any())
            {
                var combinedCriteria = _criteria.First().And(newCriteria);
                _criteria.Clear();
                _criteria.Add(combinedCriteria);
            }
            else
            {
                _criteria.Add(newCriteria);
            }
            return this;
        }

        public ISpecification<TEntity> Or(Expression<Func<TEntity, bool>> otherCriteria)
        {
            var newCriteria = otherCriteria;
            if (_criteria.Any())
            {
                var combinedCriteria = _criteria.First().Or(newCriteria);
                _criteria.Clear();
                _criteria.Add(combinedCriteria);
            }
            else
            {
                _criteria.Add(newCriteria);
            }
            return this;
        }

        public ISpecification<TEntity> Not(Expression<Func<TEntity, bool>> criteria)
        {
            var notCriteria = criteria.Not();
            _criteria.Add(notCriteria);
            return this;
        }
    }
}
