using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class SpellRepository : BaseLinkRepository<SpellModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public SpellRepository(RealmDbContext context) : base(context) { }
    }

}
