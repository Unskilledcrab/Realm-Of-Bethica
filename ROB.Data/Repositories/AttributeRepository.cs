using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class AttributeRepository : BaseRepository<AttributeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public AttributeRepository(RealmDbContext context) : base(context) { }
    }

}
