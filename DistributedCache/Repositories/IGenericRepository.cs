using System.Linq.Expressions;

namespace DistributedCache.Repositories
{
    public interface IGenericRepository<T> where T:class 
    {
        Task<T> GetById(int id);
        Task<T> GetItem(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task Add(T  entity);
        Task AddRange(IEnumerable<T> entities);
        void Update(T entity);
        Task Remove(T entity);
       // Task RemoveRange(IEnumerable<T> entities);
    }
}
