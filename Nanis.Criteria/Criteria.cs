using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Nanis.Criteria
{
    public abstract class Criteria<T> : ICriteria<T> where T : class
    {
        private Expression<Func<T, bool>> _criteria;
        public Expression<Func<T, bool>> GetCriteria => _criteria;
        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; private set; }
        public IList<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes_ { get; } =
            new List<Func<IQueryable<T>, IIncludableQueryable<T, object>>>();

        public Expression<Func<T,object>> Selector { get;  set; }
        public Criteria()
        {

        }
        protected void And(Expression<Func<T, bool>> criteria)
        {
            if (_criteria == null)
            {
                throw new ArgumentNullException(nameof(criteria));
            }

            _criteria = CombineExpressions<T>.Combine(_criteria, criteria, ExpressionType.AndAlso);
                
        }

        protected void Or(Expression<Func<T, bool>> criteria)
        {
            if (_criteria == null)
            { 
                throw new ArgumentNullException(nameof(criteria));
            }

            _criteria = CombineExpressions<T>.Combine(_criteria, criteria, ExpressionType.OrElse);
        }

        public Criteria<T> Not()
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
            if(includes == null)
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
        public void AddOrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            if (orderBy == null)
                throw new ArgumentNullException(nameof(OrderBy));

            OrderBy = orderBy;
        }


    }
}
