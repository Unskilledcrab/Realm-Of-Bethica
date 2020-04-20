using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class TalentGroupTypeRepository : BaseRepository<TalentGroupTypeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public TalentGroupTypeRepository(RealmDbContext context) : base(context) { }
    }

}
