using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class ItemRepository : BaseLinkRepository<ItemModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ItemRepository(RealmDbContext context) : base(context) { }
    }

}
