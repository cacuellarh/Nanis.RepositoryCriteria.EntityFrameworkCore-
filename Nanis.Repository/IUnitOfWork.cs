using System.Transactions;

namespace Nanis.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        public Task<int> Commit();
        public IRepository<T> Repository<T>() where T : class;
        public void BeginTransaction(IsolationLevel isolationLevel);
        public void RollBack();
    }
}
