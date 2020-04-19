using Microsoft.EntityFrameworkCore;
using ROB.Core.Models;
using ROB.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ROB.Data.Repositories
{
    public abstract class BaseCharacterOwnedRepository<TEntity> : BaseRepository<TEntity>, ICharacterOwnedRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        public BaseCharacterOwnedRepository(DbContext context) : base(context) { }

        public async Task AddRangeToCharacterAsync<TLinkEntity>(IEnumerable<TLinkEntity> linkEntities) where TLinkEntity : class
        {
            await Context.Set<TLinkEntity>().AddRangeAsync(linkEntities);
        }

        public async Task AddToCharacterAsync<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class
        {
            await Context.Set<TLinkEntity>().AddAsync(linkEntity);
        }

        public void RemoveFromCharacter<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class
        {
            Context.Set<TLinkEntity>().Remove(linkEntity);
        }

        public void RemoveRangeFromCharacter<TLinkEntity>(IEnumerable<TLinkEntity> linkEntities) where TLinkEntity : class
        {
            Context.Set<TLinkEntity>().RemoveRange(linkEntities);
        }
    }
}
