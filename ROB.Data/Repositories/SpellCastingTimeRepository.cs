using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class SpellCastingTimeRepository : BaseRepository<SpellCastingTimeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public SpellCastingTimeRepository(RealmDbContext context) : base(context) { }
    }

}
