using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class ArcaneSubgroupRepository : BaseLinkRepository<ArcaneSubgroupModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ArcaneSubgroupRepository(RealmDbContext context) : base(context) { }
    }

}
