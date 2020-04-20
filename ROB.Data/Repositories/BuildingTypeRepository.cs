using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class BuildingTypeRepository : BaseRepository<BuildingTypeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public BuildingTypeRepository(RealmDbContext context) : base(context) { }
    }

}
