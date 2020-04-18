using Microsoft.EntityFrameworkCore;
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

        public void RemoveFromPlayerById<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class
        {
            throw new NotImplementedException();
        }
    }
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public BaseRepository(DbContext context)
        {
            Context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async ValueTask<TEntity> GetByIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetPageByRecent(int pageIndex = 0, int pageSize = 10, bool orderByRecent = true)
        {
            return await Context.Set<TEntity>()
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetTop(int count, bool orderByRecent = true)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefaultAsync(predicate);
        }
    }
}
