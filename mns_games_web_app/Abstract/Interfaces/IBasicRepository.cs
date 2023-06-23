using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace mns_games_web_app.Abstract.Interfaces
{
    public interface IBasicRepository<T> where T : class
    {
        Task<T?> GetAsync(int? id);
        Task<T> GetIncludesAsync(int? id, params Expression<Func<T, object>>[] includeProperties);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllIncludesAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);

    }
}
