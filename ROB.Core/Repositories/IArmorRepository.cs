using ROB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ROB.Core.Repositories
{
    public interface IArmorRepository : ILinkRepository<ArmorModel> 
    {
        Task<IEnumerable<ArmorModel>> Get(Expression<Func<ArmorModel, bool>> predicate, bool includeRestoration, bool includeRestriction, Expression<Func<ArmorModel, bool>> wherePredicate = null, bool trackingEnabled = true);
        Task<IEnumerable<ArmorModel>> GetByRestorationIdAsync(int restorationId, bool includeRestoration, bool includeRestriction, Expression<Func<ArmorModel, bool>> wherePredicate = null, bool trackingEnabled = true);
        Task<IEnumerable<ArmorModel>> GetByRestrictionIdAsync(int restrictionId, bool includeRestoration, bool includeRestriction, Expression<Func<ArmorModel, bool>> wherePredicate = null, bool trackingEnabled = true);
        Task<IEnumerable<ArmorModel>> GetByCharacterSheetIdAsync(int characterSheetId, bool includeRestoration, bool includeRestriction, Expression<Func<ArmorModel, bool>> wherePredicate = null, bool trackingEnabled = true);
    }
}
