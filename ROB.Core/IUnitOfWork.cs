using System;
using System.Threading.Tasks;
using ROB.Core.Repositories;

namespace ROB.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository User { get; }

        IArcanePowerAttributeRepository ArcanePowerAttribute { get; }

        IArmorRepository Armor { get; }

        Task<int> CommitAsync();
    }
}
