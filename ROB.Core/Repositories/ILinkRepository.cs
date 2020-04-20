using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ROB.Core.Repositories
{
    /// <summary>
    /// Anything that will have a many to many relationship will have the basic funcationality of adding and removing those relationships
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ILinkRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        Task AddLinkAsync<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class;
        Task AddLinkRangeAsync<TLinkEntity>(IEnumerable<TLinkEntity> linkEntities) where TLinkEntity : class;
        void RemoveLink<TLinkEntity>(TLinkEntity linkEntity) where TLinkEntity : class;
        void RemoveLinkRange<TLinkEntity>(IEnumerable<TLinkEntity> linkEntities) where TLinkEntity : class;
    }
}
