using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class TechniqueRepository : BaseLinkRepository<TechniqueModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public TechniqueRepository(RealmDbContext context) : base(context) { }
    }

}
