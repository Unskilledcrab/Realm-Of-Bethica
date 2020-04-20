using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class ArcanePowerAttributeRepository : BaseLinkRepository<ArcanePowerAttributeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ArcanePowerAttributeRepository(RealmDbContext context) : base(context) { }
    }

}
