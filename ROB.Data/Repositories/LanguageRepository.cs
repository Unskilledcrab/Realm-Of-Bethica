using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class LanguageRepository : BaseRepository<LanguageModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public LanguageRepository(RealmDbContext context) : base(context) { }
    }

}
