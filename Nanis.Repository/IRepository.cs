namespace Nanis.Repository
{
    public interface IRepository<T> : IAsyncRepository<T>, ISyncRepository<T>
        where T : class
    {
    }
}
