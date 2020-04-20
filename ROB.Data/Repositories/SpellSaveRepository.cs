using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class SpellSaveRepository : BaseRepository<SpellSaveModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public SpellSaveRepository(RealmDbContext context) : base(context) { }
    }

}
