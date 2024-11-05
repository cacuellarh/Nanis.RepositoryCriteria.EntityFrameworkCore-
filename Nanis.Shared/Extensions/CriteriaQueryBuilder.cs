using Nanis.Shared.Criteria;
using Nanis.Shared.Exceptions;

namespace Nanis.Shared;

public static class Queryable
{
    public static IQueryable<T> BuildCriteriaQuery<T>(this IQueryable<T> queryable, 
        ICriteria<T> criteria)
        where T : class
    {
        if (criteria == null)
        {
            throw new CriteriaNullException(nameof(criteria));
        }

        bool hasAnyCriteria = criteria.GetCriteria != null ||
                              criteria.Includes_?.Any() == true ||
                              criteria.OrderBy != null ||
                              criteria.Selector != null ||
                              criteria.Pagination != null;

        if (!hasAnyCriteria)
        {
            throw new CriteriaPropertiesAreNullException("At least one criterion must be applied to filter or sort the query.",
                nameof(criteria));
        }

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
            var orderedQuery = criteria.OrderBy(queryable);

            if (criteria.ThenBy != null)
            {
                orderedQuery = criteria.ThenBy(orderedQuery);
            }
            queryable = orderedQuery;
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
