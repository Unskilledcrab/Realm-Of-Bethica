using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class TownRepository : BaseLinkRepository<TownModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public TownRepository(RealmDbContext context) : base(context) { }
    }

}
