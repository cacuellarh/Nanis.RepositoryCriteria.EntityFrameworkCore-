using Nanis.Shared.Criteria;

namespace Nanis.Repository
{
    public interface ISyncRepository<T> where T : class
    {
        public void Create(T entity);
        public void Delete(T entity);
        public void Update(T entity);
        public T? Get(ICriteria<T> criteria);
        public ICollection<T>? GetAll();
        public ICollection<T>? GetAll(ICriteria<T> criteriay);
    }
}
