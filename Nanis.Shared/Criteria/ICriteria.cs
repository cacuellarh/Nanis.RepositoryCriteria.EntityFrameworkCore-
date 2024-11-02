using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Nanis.Shared.Criteria
{
    public interface ICriteria<T>
    {
        Expression<Func<T, bool>> GetCriteria { get; }
        IList<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes_ { get; }
        Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; }
        Expression<Func<T, object>> Selector { get; set; }

        void AddCriteria(Expression<Func<T, bool>> criteria);
        void AddInclude(params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes);
        void AddOrderBy(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        ICriteria<T> Not();
    }
}
