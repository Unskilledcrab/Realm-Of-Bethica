using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class ArcaneSphereRepository : BaseRepository<ArcaneSphereModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ArcaneSphereRepository(RealmDbContext context) : base(context) { }
    }

}
