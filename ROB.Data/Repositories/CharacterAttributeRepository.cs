using ROB.Core.Models;

namespace ROB.Data.Repositories
{
    public class CharacterAttributeRepository : BaseRepository<CharacterAttributeModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public CharacterAttributeRepository(RealmDbContext context) : base(context) { }
    }

}
