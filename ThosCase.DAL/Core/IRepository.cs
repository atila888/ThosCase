using System.Linq.Expressions;

namespace ThosCase.DAL.Core
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);

        Task<TEntity> GetAsync(int id);

        TEntity Get(long id);

        Task<TEntity> GetAsync(long id);

        IEnumerable<TEntity> GetAll();

        Task<IEnumerable<TEntity>> GetAllAsync();

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);

        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        void Add(TEntity entity);

        Task AddAsync(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity CreateNewInstance();

        void SaveAsync();
    }
}
