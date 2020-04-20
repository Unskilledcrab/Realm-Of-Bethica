using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class LanguageGroupTypeRepository : BaseRepository<LanguageGroupTypeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public LanguageGroupTypeRepository(RealmDbContext context) : base(context) { }
    }

}
