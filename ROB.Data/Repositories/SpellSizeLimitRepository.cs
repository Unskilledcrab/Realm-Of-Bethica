using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class SpellSizeLimitRepository : BaseRepository<SpellSizeLimitModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public SpellSizeLimitRepository(RealmDbContext context) : base(context) { }
    }

}
