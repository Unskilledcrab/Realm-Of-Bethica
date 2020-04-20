using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class WeaponTypeRepository : BaseRepository<WeaponTypeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public WeaponTypeRepository(RealmDbContext context) : base(context) { }
    }

}
