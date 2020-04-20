using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class QuestGroupRepository : BaseLinkRepository<QuestGroupModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public QuestGroupRepository(RealmDbContext context) : base(context) { }
    }

}
