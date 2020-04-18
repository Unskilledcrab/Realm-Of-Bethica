using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ROB.Core.Repositories
{
    /// <summary>
    /// Everything that is able to be bound to a player
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ICharacterOwnedRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdWithPlayerByIdAsync<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class;
        Task<IEnumerable<TEntity>> GetWithPlayerByIdAsync<TKey>(Expression<Func<TEntity, TKey>> predicate = null);
        Task AddToPlayerByIdAsync<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class;
        void RemoveFromPlayerById<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class;   
    }
}
