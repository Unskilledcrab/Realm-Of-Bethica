using ROB.Core;
using ROB.Core.Repositories;
using ROB.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ROB.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RealmDbContext context;
        private ArmorRepository armorRepository;

        public IArmorRepository Armor => armorRepository = armorRepository ?? new ArmorRepository(context);

        public UnitOfWork(RealmDbContext context)
        {
            this.context = context;
        }

        public async Task<int> CommitAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
