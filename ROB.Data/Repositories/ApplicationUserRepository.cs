using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class ApplicationUserRepository : BaseLinkRepository<ApplicationUser>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ApplicationUserRepository(RealmDbContext context) : base(context) { }
    }

}
