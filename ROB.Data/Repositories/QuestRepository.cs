using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class QuestRepository : BaseLinkRepository<QuestModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public QuestRepository(RealmDbContext context) : base(context) { }
    }

}
