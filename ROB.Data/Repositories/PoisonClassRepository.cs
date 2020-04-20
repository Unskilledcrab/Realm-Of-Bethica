using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class PoisonClassRepository : BaseRepository<PoisonClassModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public PoisonClassRepository(RealmDbContext context) : base(context) { }
    }

}
