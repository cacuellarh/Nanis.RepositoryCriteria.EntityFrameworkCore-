using System.Transactions;

namespace Nanis.Shared
{
    /// <summary>
    /// Defines a unit of work that encapsulates a transaction across multiple repository operations.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commits all changes within the unit of work to the underlying data store.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation. 
        /// Returns the number of entities affected by the commit.</returns>
        Task<int> Commit();

        /// <summary>
        /// Provides access to a repository of the specified entity type.
        /// </summary>
        /// <typeparam name="T">The type of entity managed by the repository.</typeparam>
        /// <typeparam name="TRepository">The type of the repository to return.</typeparam>
        /// <returns>An instance of <typeparamref name="TRepository"/> for the specified entity type.</returns>
        TRepository Repository<T, TRepository>() where T : class;

        /// <summary>
        /// Begins a transaction with the specified isolation level.
        /// </summary>
        /// <param name="isolationLevel">The isolation level for the transaction.</param>
        void BeginTransaction(IsolationLevel isolationLevel);

        /// <summary>
        /// Rolls back any changes made within the current transaction.
        /// </summary>
        void RollBack();
    }
}