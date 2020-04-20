using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class WeaponRepository : BaseLinkRepository<WeaponModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public WeaponRepository(RealmDbContext context) : base(context) { }
    }

}
