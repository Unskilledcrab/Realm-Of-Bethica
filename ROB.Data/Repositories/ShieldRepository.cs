using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class ShieldRepository : BaseLinkRepository<ShieldModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ShieldRepository(RealmDbContext context) : base(context) { }
    }

}
