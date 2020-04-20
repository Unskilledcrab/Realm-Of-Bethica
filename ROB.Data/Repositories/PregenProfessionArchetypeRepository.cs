using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class PregenProfessionArchetypeRepository : BaseLinkRepository<PregenProfessionArchetypeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public PregenProfessionArchetypeRepository(RealmDbContext context) : base(context) { }
    }

}
