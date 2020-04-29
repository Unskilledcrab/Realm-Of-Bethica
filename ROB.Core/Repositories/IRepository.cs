using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ROB.Core.Repositories
{
    /// <summary>
    /// Base Repository
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> GetTop(int count);
        Task<IEnumerable<TEntity>> GetTop(int count, Expression<Func<TEntity, bool>> wherePredicate);
        Task<IEnumerable<TEntity>> GetTop<TKey>(int count, Expression<Func<TEntity, bool>> wherePredicate, Expression<Func<TEntity, TKey>> orderByPredicate);
        /// <summary>
        /// Returns a page (set number) of IEnuerable<typeparamref name="TEntity"/> used to page through the entities in the database
        /// </summary>
        /// <param name="pageIndex">The page you would like to see</param>
        /// <param name="pageSize">The page size</param>
        /// <returns><paramref name="pageSize"/> of IEnumerable <typeparamref name="TEntity"/></returns>
        Task<IEnumerable<TEntity>> GetPage(int pageIndex = 1, int pageSize = 10);
        /// <summary>
        /// Returns a page (set number) of IEnuerable<typeparamref name="TEntity"/> used to page through the entities in the database
        /// </summary>
        /// <param name="pageIndex">The page you would like to see</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="wherePredicate">The "where" expression</param>
        /// <returns><paramref name="pageSize"/> of IEnumerable <typeparamref name="TEntity"/></returns>
        Task<IEnumerable<TEntity>> GetPage(Expression<Func<TEntity, bool>> wherePredicate, int pageIndex = 1, int pageSize = 10);
        /// <summary>
        /// Returns a page (set number) of IEnuerable<typeparamref name="TEntity"/> used to page through the entities in the database
        /// </summary>
        /// <typeparam name="TKey">The property you want to order by</typeparam>
        /// <param name="pageIndex">The page you would like to see</param>
        /// <param name="pageSize">The page size</param>
        /// <param name="wherePredicate">The "where" expression</param>
        /// <param name="orderByPredicate">The "order by" expression</param>
        /// <returns><paramref name="pageSize"/> of IEnumerable <typeparamref name="TEntity"/></returns>
        Task<IEnumerable<TEntity>> GetPage<TKey>(Expression<Func<TEntity, bool>> wherePredicate, Expression<Func<TEntity, TKey>> orderByPredicate, int pageIndex = 1, int pageSize = 10);
    }
}
