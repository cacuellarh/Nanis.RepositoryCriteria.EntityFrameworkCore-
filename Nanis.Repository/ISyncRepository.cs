using Nanis.Criteria;

namespace Nanis.Repository
{
    public interface ISyncRepository<T> where T : class
    {
        public void Create(T entity);
        public void Delete(T entity);
        public void Update(T entity);
        public T? Get(Criteria<T> criteria);
        public ICollection<T>? GetAll();
        public ICollection<T>? GetAll(Criteria<T> criteriay);
    }
}
