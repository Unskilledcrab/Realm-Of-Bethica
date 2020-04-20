using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class CharacterSheetRepository : BaseLinkRepository<CharacterSheetModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public CharacterSheetRepository(RealmDbContext context) : base(context) { }
    }

}
