using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class PoisonRepository : BaseLinkRepository<PoisonModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public PoisonRepository(RealmDbContext context) : base(context) { }
    }

}
