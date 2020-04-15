using System;
using System.Threading.Tasks;
using ROB.Core.Repositories;

namespace ROB.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IArmorRepository Armor { get; }
        Task<int> CommitAsync();
    }
}
