using Microsoft.EntityFrameworkCore;
using mns_games_web_app.Abstract.Interfaces;
using mns_games_web_app.Data;
using System.Linq.Expressions;

namespace mns_games_web_app.Repositories
{
    public class BasicRepository<T> : IBasicRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        
        public BasicRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRangeAsync(List<T> entities)
        {
           await _context.AddRangeAsync(entities);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await GetAsync(id);
            return entity != null;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllIncludesAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> GetAsync(int? id)
        {
            if(id == null)
            {
                return null;
            }

            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetIncludesAsync(int? id, params Expression<Func<T, object>>[] includeProperties)
        {
            if (id == null)
            {
                return null;
            }

            IQueryable<T> query = _context.Set<T>();

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            var keyProperty = _context.Model.FindEntityType(typeof(T)).FindPrimaryKey().Properties.FirstOrDefault();
            var parameter = Expression.Parameter(typeof(T));
            var predicate = Expression.Lambda<Func<T, bool>>(
                Expression.Equal(Expression.Property(parameter, keyProperty.Name), Expression.Constant(id)),
                parameter);

            return await query.FirstOrDefaultAsync(predicate);
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
