using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class SpellRangeRepository : BaseRepository<SpellRangeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public SpellRangeRepository(RealmDbContext context) : base(context) { }
    }

}
