using ROB.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ROB.Core.Repositories
{
    public interface IArmorRepository : ILinkRepository<ArmorModel> 
    {
        Task<IEnumerable<ArmorModel>> GetWithArmorRestorationAndRestrictionsAsync();
        Task<IEnumerable<ArmorModel>> GetWithArmorRestorationAndRestrictionsByRestorationIdAsync(int id);
        Task<IEnumerable<ArmorModel>> GetWithArmorRestorationAndRestrictionsByRestrictionIdAsync(int id);
        Task<ArmorModel> GetWithArmorRestorationAndRestrictionsByIdAsync(int id);
    }
}
