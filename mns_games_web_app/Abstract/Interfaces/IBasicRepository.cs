using System.Runtime.CompilerServices;

namespace mns_games_web_app.Abstract.Interfaces
{
    public interface IBasicRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<List<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<bool> Exists(int id);
    }
}
