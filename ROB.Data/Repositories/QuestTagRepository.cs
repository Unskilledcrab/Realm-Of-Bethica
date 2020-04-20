using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class QuestTagRepository : BaseLinkRepository<QuestTagModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public QuestTagRepository(RealmDbContext context) : base(context) { }
    }

}
