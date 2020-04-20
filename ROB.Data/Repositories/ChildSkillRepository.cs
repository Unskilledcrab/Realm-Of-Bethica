using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class ChildSkillRepository : BaseLinkRepository<ChildSkillModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ChildSkillRepository(RealmDbContext context) : base(context) { }
    }

}
