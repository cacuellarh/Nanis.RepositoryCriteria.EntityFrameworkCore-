using Microsoft.EntityFrameworkCore.Query;
using Nanis.Shared.Extensions;
using Nanis.Shared.Types;
using System.Linq.Expressions;

namespace Nanis.Shared.Criteria
{
    public interface ICriteria<T>
    {
        Expression<Func<T, bool>> GetCriteria { get; }
        IList<Func<IQueryable<T>, IIncludableQueryable<T, object>>>? Includes_ { get; }
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; }
        public Func<IOrderedQueryable<T>, IOrderedQueryable<T>>? ThenBy { get;}
        public Pagination? Pagination { get; }
        Expression<Func<T, object>>? Selector { get; set; }
        void AddCriteria(Expression<Func<T, bool>> criteria);
        void AddInclude(params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes);
        void AddOrderBy(Expression<Func<T, object>> keySelector,
            OrderByType orderType);
        ICriteria<T> Not();
        public void AddThenBy(Expression<Func<T, object>> keySelector, OrderByType orderType);
        public void ClearCriteria();
    }
}
