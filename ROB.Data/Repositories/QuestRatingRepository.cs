using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class QuestRatingRepository : BaseRepository<QuestRatingModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public QuestRatingRepository(RealmDbContext context) : base(context) { }
    }

}
