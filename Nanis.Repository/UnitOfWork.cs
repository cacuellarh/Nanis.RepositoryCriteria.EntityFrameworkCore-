using Microsoft.EntityFrameworkCore;
using Nanis.Repository.Factory;
using System.Transactions;
using System.Reflection;

namespace Nanis.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _context;
        private Dictionary<Type, object> _repositories;
        private TransactionScope _transactionScope;
        public UnitOfWork(DbContext context)
        {
            _context = context;
            _repositories = RepositoryFactory.GetRepositories(Assembly.GetCallingAssembly(), _context);
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

        public IRepository<T> Repository<T>() where T : class
        {
            var EntityType = typeof(T);

            foreach (var (type,instance) in _repositories)
            {
                var genericArgument = type.BaseType
                    .GetGenericArguments()
                    .FirstOrDefault(t => t == EntityType);

                if (genericArgument != null) 
                {
                    return (IRepository<T>)instance;
                }
            }

            return new RepositoryBase<T>(_context);
        }

    }
}
