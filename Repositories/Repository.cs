using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Database;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entityReturned = await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
            return entityReturned.Entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await context.Set<TEntity>().Select(a => a).ToListAsync();
        }

        public async Task<TEntity> GetAsync(int entityID)
        {
            return await context.Set<TEntity>().FindAsync(entityID);
        }

        public async Task RemoveAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public async Task UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }
        public async Task<bool> ContainsAsync(TEntity entity)
        {
            return await context.Set<TEntity>().ContainsAsync(entity);
        }
    }
}