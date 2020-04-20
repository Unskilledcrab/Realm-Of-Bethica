using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class ModifierRepository : BaseLinkRepository<ModifierModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ModifierRepository(RealmDbContext context) : base(context) { }
    }

}
