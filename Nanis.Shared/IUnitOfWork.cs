using System.Transactions;

namespace Nanis.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        public Task<int> Commit();
        public TRepository Repository<T, TRepository>() where T : class;
        public void BeginTransaction(IsolationLevel isolationLevel);
        public void RollBack();
    }
}
