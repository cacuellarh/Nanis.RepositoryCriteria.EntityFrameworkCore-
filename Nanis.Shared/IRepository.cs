using Nanis.Repository;

namespace Nanis.Shared
{
    public interface IRepository<T> : IAsyncRepository<T>, ISyncRepository<T>
        where T : class
    {
    }
}
