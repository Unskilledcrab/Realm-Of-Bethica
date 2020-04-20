using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class BuildingSpecialtyRepository : BaseRepository<BuildingSpecialtyModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public BuildingSpecialtyRepository(RealmDbContext context) : base(context) { }
    }

}
