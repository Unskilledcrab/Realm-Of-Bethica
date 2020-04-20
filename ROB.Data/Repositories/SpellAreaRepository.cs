using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class SpellAreaRepository : BaseRepository<SpellAreaModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public SpellAreaRepository(RealmDbContext context) : base(context) { }
    }

}
