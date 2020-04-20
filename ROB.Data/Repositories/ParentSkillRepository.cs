using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class ParentSkillRepository : BaseLinkRepository<ParentSkillModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ParentSkillRepository(RealmDbContext context) : base(context) { }
    }

}
