using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class WorldRepository : BaseLinkRepository<WorldModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public WorldRepository(RealmDbContext context) : base(context) { }
    }

}
