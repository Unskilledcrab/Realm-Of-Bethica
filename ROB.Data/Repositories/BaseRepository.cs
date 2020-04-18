using Microsoft.EntityFrameworkCore;
using ROB.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ROB.Data.Repositories
{
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

        /// <summary>
        /// Returns a page (set number) of IEnuerable<typeparamref name="TEntity"/> used to page through the entities in the database
        /// </summary>
        /// <typeparam name="TKey">The property you want to order by</typeparam>
        /// <param name="pageIndex">The page you would like to see</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="wherePredicate">The "where" expression</param>
        /// <param name="orderByPredicate">The "order by" expression</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetPage<TKey>(int pageIndex = 1, int pageSize = 10, Expression<Func<TEntity, bool>> wherePredicate = null, Expression<Func<TEntity, TKey>> orderByPredicate = null)
        {
            pageIndex = pageIndex < 1 ? 1 : pageIndex;

            var query = Context.Set<TEntity>();

            if (wherePredicate != null)
                query.Where(wherePredicate);

            if (orderByPredicate != null)
                query.OrderBy(orderByPredicate);
                
            query.Skip((pageIndex - 1) * pageSize)
                .Take(pageSize);

            return await query.ToListAsync();
        }

        /// <summary>
        /// Returns the top <paramref name="count"/> of <typeparamref name="TEntity"/> from the database
        /// </summary>
        /// <typeparam name="TKey">The property you want to order by</typeparam>
        /// <param name="count">The amount of <typeparamref name="TEntity"/> you want to return</param>
        /// <param name="wherePredicate">The "where" expression</param>
        /// <param name="orderByPredicate">The "order by" expression</param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetTop<TKey>(int count, Expression<Func<TEntity, bool>> wherePredicate = null, Expression<Func<TEntity, TKey>> orderByPredicate = null)
        {
            return await GetPage(pageSize: count, wherePredicate: wherePredicate, orderByPredicate: orderByPredicate);
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
