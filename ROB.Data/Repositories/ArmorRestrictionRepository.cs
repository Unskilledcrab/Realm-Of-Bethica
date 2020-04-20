using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class ArmorRestrictionRepository : BaseRepository<ArmorRestrictionModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ArmorRestrictionRepository(RealmDbContext context) : base(context) { }
    }

}
