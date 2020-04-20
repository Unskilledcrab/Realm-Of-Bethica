using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class PoisonTypeRepository : BaseRepository<PoisonTypeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public PoisonTypeRepository(RealmDbContext context) : base(context) { }
    }

}
