using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class WeaponSizeRepository : BaseRepository<WeaponSizeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public WeaponSizeRepository(RealmDbContext context) : base(context) { }
    }

}
