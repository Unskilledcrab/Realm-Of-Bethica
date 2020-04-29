using Microsoft.EntityFrameworkCore;
using ROB.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ROB.Data.Repositories
{
    public abstract class BaseCharacterOwnedRepository<TEntity> : BaseRepository<TEntity>, ICharacterOwnedRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public BaseCharacterOwnedRepository(DbContext context) : base(context) { }

        public async Task AddToPlayerByIdAsync<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class
        {
            await Context.Set<TLinkEntity>().AddAsync(linkEntity);
        }

        public ValueTask<TEntity> GetByIdWithPlayerByIdAsync<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TEntity>> GetWithPlayerByIdAsync<TLinkEntity>(int characterSheetId) where TLinkEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetWithPlayerByIdAsync<TKey>(System.Linq.Expressions.Expression<Func<TEntity, TKey>> predicate = null)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromPlayerById<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class
        {
            throw new NotImplementedException();
        }
    }
}
