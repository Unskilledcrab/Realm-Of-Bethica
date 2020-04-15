using System.Collections.Generic;
using System.Threading.Tasks;

namespace ROB.Core.Repositories
{
    public interface IItemRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdWithPlayerByIdAsync(string playerId, int entityId);
        Task<IEnumerable<TEntity>> GetWithPlayerByIdAsync(string playerId);
        Task AddToPlayerByIdAsync(string playerId, TEntity entity);
        void RemoveFromPlayerById(string playerId, TEntity entity);
    }
}
