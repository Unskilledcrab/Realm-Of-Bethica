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
        Task<IEnumerable<TEntity>> GetPage(int pageIndex = 1, int pageSize = 10);
        Task<IEnumerable<TEntity>> GetPage(Expression<Func<TEntity, bool>> wherePredicate, int pageIndex = 1, int pageSize = 10);
        Task<IEnumerable<TEntity>> GetPage<TKey>(Expression<Func<TEntity, bool>> wherePredicate, Expression<Func<TEntity, TKey>> orderByPredicate, int pageIndex = 1, int pageSize = 10);
    }
}
