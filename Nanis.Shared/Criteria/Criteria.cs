using Microsoft.EntityFrameworkCore.Query;
using Nanis.Criteria;
using Nanis.Shared.Exceptions;
using Nanis.Shared.Extensions;
using Nanis.Shared.Types;
using System.Linq.Expressions;
namespace Nanis.Shared.Criteria
{
    public abstract class Criteria<T> : ICriteria<T>
    {
        private Expression<Func<T, bool>> _criteria;
        public Expression<Func<T, bool>> GetCriteria => _criteria;
        public Pagination? Pagination { get; private set; }
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; private set; }
        public Func<IOrderedQueryable<T>, IOrderedQueryable<T>>? ThenBy { get; private set; }
        public IList<Func<IQueryable<T>, IIncludableQueryable<T, object>>>? Includes_ { get; } =
            new List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();
        public Expression<Func<T, object>>? Selector { get; set; }
        public Criteria()
        {

        }
        protected void And(params Expression<Func<T, bool>>[] criterias)
        {
            foreach (var criteria in criterias) 
            {         
                if (_criteria == null)
                {
                    throw new CriteriaNullException(nameof(criteria));
                }
                _criteria = CombineExpressions<T>.Combine(_criteria, criteria, ExpressionType.AndAlso);
            }
        }

        protected void Or(params Expression<Func<T, bool>>[] criterias)
        {
            foreach (var criteria in criterias)
            {                
                if (_criteria == null)
                {
                    throw new CriteriaNullException(nameof(criteria));
                }
                _criteria = CombineExpressions<T>.Combine(_criteria, criteria, ExpressionType.OrElse);
            }
        }

        public ICriteria<T> Not()
        {
            if (_criteria == null)
            {
                throw new CriteriaNullException(nameof(_criteria));
            }
            _criteria = _criteria.Not();

            return this;
        }

        public void AddInclude(params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes)
        {
            if (includes == null)
            {
                throw new ArgumentNullException(nameof(includes),
                    "The includes parameter cannot be null. Please provide one or more valid include expressions.");
            }

            foreach (var include in includes)
            {
                if (include == null)
                {
                    throw new ArgumentException("One of the include functions is null. Please provide only valid include expressions.", nameof(includes));
                }

                Includes_.Add(include);
            }
        }

        public void AddCriteria(Expression<Func<T, bool>> criteria)
        {
            if (criteria == null)
                throw new CriteriaNullException(nameof(_criteria));

            _criteria = criteria;
        }
        public void AddOrderBy(Expression<Func<T, object>> keySelector, OrderByType orderType)
        {
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector),
                    "The key selector expression cannot be null. Please provide a valid expression to order the query.");

            OrderBy = orderType == OrderByType.Ascending
                ? query => query.OrderBy(keySelector)
                : query => query.OrderByDescending(keySelector);
        }

        public void AddThenBy(Expression<Func<T, object>> keySelector, OrderByType orderType)
        {
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

            ThenBy = orderType == OrderByType.Ascending
                ? query => query.ThenBy(keySelector)
                : query => query.ThenByDescending(keySelector);
        }

        public void AddPagination(int skip, int page)
        {
            if(skip < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(skip), $"the value of skip {skip}, cannot be a negative number");
            }

            if (page < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(page), $"the value of page {page}, cannot be a negative number");
            }
            Pagination = new Pagination(skip, page);
        }

        public void ClearCriteria()
        {
            _criteria = null; 
            Pagination = null; 
            OrderBy = null; 
            ThenBy = null; 
            Includes_.Clear(); 
            Selector = null; 
        }

    }
}
