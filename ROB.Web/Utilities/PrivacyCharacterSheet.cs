using Microsoft.EntityFrameworkCore;
using ROB.Web.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Utilities
{
    public static class PrivacyCharacterSheet
    {
        public static async Task<bool> IsSheetOwner(ApplicationDbContext context, string userId, int sheetId)
        {
            return await context.CharacterSheetModel.Where(c => c.Id == sheetId && c.CreatorId == userId).AnyAsync().ConfigureAwait(false);
        }
    }
}
