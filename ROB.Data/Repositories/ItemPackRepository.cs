using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class ItemPackRepository : BaseLinkRepository<ItemPackModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ItemPackRepository(RealmDbContext context) : base(context) { }
    }

}
