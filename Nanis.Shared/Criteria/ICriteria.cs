using Microsoft.EntityFrameworkCore.Query;
using Nanis.Shared.Extensions;
using Nanis.Shared.Types;
using System.Linq.Expressions;

namespace Nanis.Shared.Criteria
{
    /// <summary>
    /// Defines a set of criteria for querying entities of type <typeparamref name="T"/> with filtering, ordering, and pagination capabilities.
    /// </summary>
    /// <typeparam name="T">The type of entity to which the criteria will be applied.</typeparam>
    public interface ICriteria<T>
    {
        /// <summary>
        /// Gets the expression that defines the filtering criteria.
        /// </summary>
        Expression<Func<T, bool>> GetCriteria { get; }

        /// <summary>
        /// Gets a collection of include expressions to specify related entities to include in the query.
        /// </summary>
        IList<Func<IQueryable<T>, IIncludableQueryable<T, object>>>? Includes_ { get; }

        /// <summary>
        /// Gets the function to apply ordering on the query.
        /// </summary>
        public Func<IQueryable<T>, IOrderedQueryable<T>>? OrderBy { get; }

        /// <summary>
        /// Gets the pagination settings for the query.
        /// </summary>
        public Pagination? Pagination { get; }

        /// <summary>
        /// Gets or sets the selector expression for projecting specific properties.
        /// </summary>
        Expression<Func<T, object>>? Selector { get; }

        /// <summary>
        /// Adds a new filter criteria to the query.
        /// </summary>
        /// <param name="criteria">The expression defining the filter criteria.</param>
        void AddCriteria(Expression<Func<T, bool>> criteria);

        /// <summary>
        /// Adds include expressions to specify related entities to be included in the query.
        /// </summary>
        /// <param name="includes">The include functions to add.</param>
        void AddInclude(params Func<IQueryable<T>, IIncludableQueryable<T, object>>[] includes);

        /// <summary>
        /// Adds an ordering criteria to the query.
        /// </summary>
        /// <param name="keySelector">The key selector expression to determine the order.</param>
        /// <param name="orderType">The type of ordering (ascending or descending).</param>
        void AddOrderBy(Expression<Func<T, object>> keySelector, OrderByType orderType);

        /// <summary>
        /// Negates the current filter criteria, applying a logical "NOT" operation.
        /// </summary>
        /// <returns>A modified instance of <see cref="ICriteria{T}"/> with the negated criteria.</returns>
        ICriteria<T> Not();

        /// <summary>
        /// Sets the selector expression for projecting specific properties.
        /// </summary>
        /// <param name="Selector">The selector expression to define the projection.</param>
        public void Select(Expression<Func<T, object>>? Selector);

        /// <summary>
        /// Adds a secondary ordering criteria to the query.
        /// </summary>
        /// <param name="keySelector">The primary key selector expression for ordering.</param>
        /// <param name="thenBySelector">The secondary key selector expression for ordering.</param>
        /// <param name="orderType">The type of ordering (ascending or descending).</param>
        public void AddOrderBy(Expression<Func<T, object>> keySelector,
            Expression<Func<T, object>> thenBySelector,
            OrderByType orderType);

        /// <summary>
        /// Clears all defined filter criteria, ordering, includes, and other settings from the query.
        /// </summary>
        public void ClearCriteria();
    }
}