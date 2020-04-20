using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class RaceRepository : BaseLinkRepository<RaceModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public RaceRepository(RealmDbContext context) : base(context) { }
    }

}
