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
    public abstract class BaseLinkRepository<TEntity> : BaseRepository<TEntity>, ILinkRepository<TEntity> where TEntity : class
    {
        public BaseLinkRepository(DbContext context) : base(context) { }

        public async Task AddLinkRangeAsync<TLinkEntity>(IEnumerable<TLinkEntity> linkEntities) where TLinkEntity : class
        {
            await Context.Set<TLinkEntity>().AddRangeAsync(linkEntities);
        }

        public async Task AddLinkAsync<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class
        {
            await Context.Set<TLinkEntity>().AddAsync(linkEntity);
        }

        public void RemoveLink<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class
        {
            Context.Set<TLinkEntity>().Remove(linkEntity);
        }

        public void RemoveLinkRange<TLinkEntity>(IEnumerable<TLinkEntity> linkEntities) where TLinkEntity : class
        {
            Context.Set<TLinkEntity>().RemoveRange(linkEntities);
        }
    }
}
