using Nanis.Shared.Criteria;

namespace Nanis.Repository
{
    /// <summary>
    /// Defines a synchronous repository for managing CRUD operations on entities of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of entity managed by this repository.</typeparam>
    public interface ISyncRepository<T> where T : class
    {
        /// <summary>
        /// Creates a new instance of the entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        void Create(T entity);

        /// <summary>
        /// Deletes an existing instance of the entity from the repository.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        void Delete(T entity);

        /// <summary>
        /// Updates an existing instance of the entity in the repository.
        /// </summary>
        /// <param name="entity">The entity to update.</param>
        void Update(T entity);

        /// <summary>
        /// Retrieves a single entity from the repository that matches the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria to apply when retrieving the entity.</param>
        /// <returns>The entity that matches the criteria, or <c>null</c> if no match is found.</returns>
        T? Get(ICriteria<T> criteria);

        /// <summary>
        /// Retrieves all entities from the repository.
        /// </summary>
        /// <returns>A collection of all entities, or <c>null</c> if no entities exist.</returns>
        ICollection<T>? GetAll();

        /// <summary>
        /// Retrieves all entities from the repository that match the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria to apply when retrieving entities.</param>
        /// <returns>A collection of entities that match the criteria, or <c>null</c> if no matches are found.</returns>
        ICollection<T>? GetAll(ICriteria<T> criteria);
    }
}