using Nanis.Shared.Criteria;

namespace Nanis.Shared
{
    /// <summary>
    /// Defines an asynchronous repository for managing CRUD operations on entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of entity managed by this repository.</typeparam>
    public interface IAsyncRepository<T> where T : class
    {
        /// <summary>
        /// Asynchronously creates a new instance of the entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task CreateAsync(T entity,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously deletes an existing instance of the entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public void DeleteAsync(T entity);

        /// <summary>
        /// Asynchronously updates an existing instance of the entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task UpdateAsync(T entity);

        /// <summary>
        /// Asynchronously retrieves a single entity from the repository that matches the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria to apply when retrieving the entity.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation, containing the entity that matches the criteria.</returns>
        public Task<T> GetAsync(ICriteria<T> criteria,
            CancellationToken cancellationToken = default);

        public Task<object> GetAsyncWithProyection(ICriteria<T> criteria,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously retrieves all entities from the repository.
        /// </summary>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation, containing a collection of all entities.</returns>
        public Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Asynchronously retrieves all entities from the repository that match the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria to apply when retrieving entities.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation, containing a collection of entities that match the criteria.</returns>
        public Task<ICollection<T>> GetAllAsync(ICriteria<T> criteria,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Retrieves all entities from the repository that match the specified criteria and applies a projection.
        /// </summary>
        /// <param name="criteria">The criteria to apply when retrieving entities.</param>
        /// <param name="cancellationToken">A token to cancel the operation if needed.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of projected entities.</returns>
        public Task<ICollection<object>> GetAllAsyncWithProyection(ICriteria<T> criteria,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Counts the number of entities in the repository that match the specified criteria asynchronously.
        /// </summary>
        /// <param name="criteria">The criteria to apply when counting entities.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of entities that match the criteria.</returns>
        public Task<int> CountAsync(ICriteria<T> criteria);

        /// <summary>
        /// Counts the total number of entities in the repository asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the total number of entities.</returns>
        public Task<int> CountAsync();
    }
}
