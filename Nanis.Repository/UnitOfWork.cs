using Microsoft.EntityFrameworkCore;
using System.Transactions;
using Nanis.Shared.Factory;

namespace Nanis.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        private Dictionary<Type, object> _repositories;
        private TransactionScope _transactionScope;
        private IRepositoryFactory _repositoryFactory;
        public UnitOfWork(DbContext context, IRepositoryFactory repositoryFactory)
        {
            _context = context;
            _repositories = _repositoryFactory.GetRepositories();
            _repositoryFactory = repositoryFactory;
        }

        public void BeginTransaction(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (_transactionScope != null)
            {
                throw new InvalidOperationException("A transaction is already in progress.");
            }
            var transactionOptions = new TransactionOptions()
            {
                IsolationLevel = isolationLevel
            };

            _transactionScope = new TransactionScope(
                TransactionScopeOption.Required,
                transactionOptions,
                TransactionScopeAsyncFlowOption.Enabled);
        }

        public async Task<int> Commit()
        {
            try
            {
                int result = await _context.SaveChangesAsync();
                _transactionScope?.Complete();
                return result;
            }
            catch
            {
                throw;
            }
            finally
            {
                DisposeTransaction();
            }
        }

        private void DisposeTransaction()
        {
            _transactionScope?.Dispose();
            _transactionScope = null;
        }

        public void Dispose()
        {
            _context.Dispose();
            _transactionScope?.Dispose();
        }

        public void RollBack()
        {
            DisposeTransaction();
        }

        public TRepository Repository<T, TRepository>()
            where T : class
        {
            var EntityType = typeof(T);

            if (!_repositories.ContainsKey(EntityType))
            {
                throw new KeyNotFoundException($"Type {typeof(TRepository).Name} doesn't implement {typeof(IRepository<>).Name}");
            }

            return (TRepository)_repositories[EntityType];
        }

    }
}
