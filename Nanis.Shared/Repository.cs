using NanisGuard;
using NanisGuard.src;
using Microsoft.EntityFrameworkCore;
using Nanis.Shared;
using Nanis.Shared.Exceptions;
using Nanis.Shared.Criteria;


namespace Nanis.Repository
{
    public class Repository<T> : IRepository<T>, IAsyncRepository<T>, ISyncRepository<T> where T : class
    {
        private readonly DbContext context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            this.context = context;
            _dbSet = this.context.Set<T>();
        }

        public void Create(T entity)
        {
            NanisGuardV.validation.NotNull(entity, customException: () => new EntityNullException());
            _dbSet.Add(entity);
        }

        public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
        {
            NanisGuardV.validation.NotNull(entity, customException: () => new EntityNullException());
            await _dbSet.AddAsync(entity, cancellationToken);
        }

        public void Delete(T entity)
        {
            NanisGuardV.validation.NotNull(entity, customException: () => new EntityNullException());
            _dbSet.Remove(entity);
        }

        public void DeleteAsync(T entity)
        {
            NanisGuardV.validation.NotNull(entity, customException: () => new EntityNullException());
            _dbSet.Remove(entity);
        }

        public T? Get(ICriteria<T> criteria)
            => _dbSet.BuildCriteriaQuery(criteria).FirstOrDefault();

        public async Task<T> GetAsync(ICriteria<T> criteria, CancellationToken cancellationToken = default)
            => await _dbSet.BuildCriteriaQuery(criteria).FirstOrDefaultAsync(cancellationToken);

        public async Task<object?> GetAsyncWithProyection(ICriteria<T> criteria, CancellationToken cancellationToken = default)
            => await _dbSet.BuildCriteriaQueryWithProjection(criteria).FirstOrDefaultAsync(cancellationToken);

        public ICollection<T>? GetAll()
            => _dbSet.ToList();

        public ICollection<T>? GetAll(ICriteria<T> criteria)
            => _dbSet.BuildCriteriaQuery(criteria).ToList();

        public async Task<ICollection<T>> GetAllAsync(CancellationToken cancellationToken = default)
            => await _dbSet.ToListAsync(cancellationToken);

        public async Task<ICollection<T>> GetAllAsync(ICriteria<T> criteria, CancellationToken cancellationToken = default)
            => await _dbSet.BuildCriteriaQuery(criteria).ToListAsync(cancellationToken);

        public void Update(T entity)
            => _dbSet.Update(entity);

        public Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return Task.CompletedTask;
        }
        public async Task<ICollection<object>> GetAllAsyncWithProyection(ICriteria<T> criteria, CancellationToken cancellationToken = default)
        {
            return await _dbSet.BuildCriteriaQueryWithProjection(criteria).ToListAsync(cancellationToken);
        }

    }
}
