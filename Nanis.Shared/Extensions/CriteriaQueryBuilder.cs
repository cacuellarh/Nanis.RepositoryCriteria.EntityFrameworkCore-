using Nanis.Shared.Criteria;
using Nanis.Shared.Exceptions;

namespace Nanis.Shared;

/// <summary>
/// Provides extension methods to build queries based on specified criteria for filtering, ordering, pagination, and projection.
/// </summary>
public static class Queryable
{
    /// <summary>
    /// Builds a query based on the provided criteria, applying filters, includes, ordering, and pagination.
    /// </summary>
    /// <typeparam name="T">The type of the entities in the query.</typeparam>
    /// <param name="queryable">The queryable to which the criteria will be applied.</param>
    /// <param name="criteria">The criteria containing the query specifications.</param>
    /// <returns>An <see cref="IQueryable{T}"/> with the applied criteria.</returns>
    /// <exception cref="CriteriaNullException">Thrown when criteria is null.</exception>
    /// <exception cref="CriteriaPropertiesAreNullException">Thrown when no criteria are specified in the provided criteria object.</exception>
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

        if (criteria.Includes_?.Any() == true)
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
        }

        if (criteria.Pagination != null)
        {
            queryable = queryable.Skip(criteria.Pagination.Page)
                .Take(criteria.Pagination.Take);
        }

        return queryable;
    }

    /// <summary>
    /// Builds a query with projection based on the provided criteria, applying filters, includes, ordering, pagination, and projection if specified.
    /// </summary>
    /// <typeparam name="T">The type of the entities in the query.</typeparam>
    /// <param name="queryable">The queryable to which the criteria will be applied.</param>
    /// <param name="criteria">The criteria containing the query specifications.</param>
    /// <returns>An <see cref="IQueryable{object}"/> with the applied criteria and projection.</returns>
    public static IQueryable<object> BuildCriteriaQueryWithProjection<T>(this IQueryable<T> queryable,
        ICriteria<T> criteria) where T : class
    {
        var baseQuery = queryable.BuildCriteriaQuery(criteria);

        if (criteria.Selector != null)
        {
            return baseQuery.Select(criteria.Selector);
        }

        return baseQuery;
    }
}