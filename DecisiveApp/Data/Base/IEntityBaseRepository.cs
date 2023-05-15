using System.Linq.Expressions;

namespace DecisiveApp.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()

    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByidAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);

    }
}
