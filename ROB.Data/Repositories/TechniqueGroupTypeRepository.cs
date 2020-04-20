using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class TechniqueGroupTypeRepository : BaseRepository<TechniqueGroupTypeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public TechniqueGroupTypeRepository(RealmDbContext context) : base(context) { }
    }

}
