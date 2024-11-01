using Nanis.Criteria;

namespace Nanis.Repository
{
    public interface IAsyncRepository<T> where T : class
    {
        public Task CreateAsync(T entity, 
            CancellationToken cancellationToken = default);
        public void DeleteAsync(T entity);
        public Task UpdateAsync(T entity);
        public Task<T> GetAsync(Criteria<T> criteria, 
            CancellationToken cancellationToken = default);
        public Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default);
        public Task<ICollection<T>> GetAllAsync(Criteria<T> criteria, 
            CancellationToken cancellationToken = default);
    }
}
