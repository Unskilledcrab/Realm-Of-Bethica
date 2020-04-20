using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class ItemCategoryRepository : BaseRepository<ItemCategoryModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ItemCategoryRepository(RealmDbContext context) : base(context) { }
    }

}
