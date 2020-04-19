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
        Task AddToCharacterAsync<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class;
        Task AddRangeToCharacterAsync<TLinkEntity>(IEnumerable<TLinkEntity> linkEntities) where TLinkEntity : class;
        void RemoveFromCharacter<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class;
        void RemoveRangeFromCharacter<TLinkEntity>(IEnumerable<TLinkEntity> linkEntities) where TLinkEntity : class;
    }
}
