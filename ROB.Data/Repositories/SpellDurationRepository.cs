using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class SpellDurationRepository : BaseRepository<SpellDurationModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public SpellDurationRepository(RealmDbContext context) : base(context) { }
    }

}
