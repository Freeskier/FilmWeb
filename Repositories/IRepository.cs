using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetAsync(int entityID);
        Task<bool> SaveAsync();
        Task<bool> ContainsAsync(TEntity entity);
    }
}