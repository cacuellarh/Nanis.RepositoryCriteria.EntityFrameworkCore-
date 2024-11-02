using Nanis.Shared.Criteria;
using Nanis.Shared.Extensions;

namespace Nanis.Shared;

public static class Queryable
{
    public static IQueryable<T> BuildCriteriaQuery<T>(this IQueryable<T> queryable, 
        ICriteria<T> criteria)
        where T : class
    {
        if (criteria.Includes_.Any())
        {
            foreach (var include in criteria.Includes_)
            {
                queryable = include(queryable);
            }
        }
        if (criteria.GetCriteria != null)
        {
            queryable = queryable.Where(criteria.GetCriteria);
        }

        if (criteria.OrderBy != null)
        {
            queryable = criteria.OrderBy(queryable);

            if (criteria.ThenBy != null)
            {
                queryable = criteria.ThenBy(criteria.OrderBy(queryable));
            }
        }

        if (criteria.Selector != null)
        {
            queryable.Select(criteria.Selector);
            queryable.OrderByDescending(criteria.Selector);
        }

        if (criteria.Pagination != null)
        {
            queryable = queryable.Skip(criteria.Pagination.Page)
                .Take(criteria.Pagination.Take);
        }
  
        return queryable;
    }
}
