using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class BuildingRatingRepository : BaseLinkRepository<BuildingRatingModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public BuildingRatingRepository(RealmDbContext context) : base(context) { }
    }

}
