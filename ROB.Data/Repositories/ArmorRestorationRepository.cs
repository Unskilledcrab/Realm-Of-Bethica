using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class ArmorRestorationRepository : BaseRepository<ArmorRestorationModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ArmorRestorationRepository(RealmDbContext context) : base(context) { }
    }

}
