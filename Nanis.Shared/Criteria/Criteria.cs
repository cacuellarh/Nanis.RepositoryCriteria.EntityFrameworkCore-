using Microsoft.EntityFrameworkCore.Query;
using Nanis.Criteria;
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
                    throw new ArgumentNullException(nameof(criteria));
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
                    throw new ArgumentNullException(nameof(criteria));
                }
                _criteria = CombineExpressions<T>.Combine(_criteria, criteria, ExpressionType.OrElse);
            }
        }

        public ICriteria<T> Not()
        {
            if (_criteria == null)
            {
                throw new ArgumentNullException(nameof(_criteria));
            }
            _criteria = _criteria.Not();

            return this;
        }

        public void AddInclude(params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes)
        {
            if (includes == null)
                throw new ArgumentNullException(nameof(includes));

            foreach (var include in includes)
            {
                if (include is not null)
                {
                    Includes_.Add(include);
                }
            }
        }

        public void AddCriteria(Expression<Func<T, bool>> criteria)
        {
            if (criteria == null)
                throw new ArgumentNullException(nameof(criteria));

            _criteria = criteria;
        }
        public void AddOrderBy(Expression<Func<T, object>> keySelector, OrderByType orderType)
        {
            if (keySelector == null)
                throw new ArgumentNullException(nameof(keySelector));

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
