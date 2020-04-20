using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class TalentRepository : BaseLinkRepository<TalentModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public TalentRepository(RealmDbContext context) : base(context) { }
    }

}
