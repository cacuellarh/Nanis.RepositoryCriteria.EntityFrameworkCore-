using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Nanis.Criteria
{
    public interface ICriteria<T> where T : class
    {
        public Expression<Func<T, bool>> GetCriteria { get; }
        public Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy { get; }
        public IList<Func<IQueryable<T>, IIncludableQueryable<T, object>>> Includes_ { get; }

    }
}
