using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class DamageTypeRepository : BaseRepository<DamageTypeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public DamageTypeRepository(RealmDbContext context) : base(context) { }
    }

}
