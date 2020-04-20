using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class BuildingRepository : BaseLinkRepository<BuildingModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public BuildingRepository(RealmDbContext context) : base(context) { }
    }

}
