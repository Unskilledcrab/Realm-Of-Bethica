using ROB.Core.Models;
using ROB.Core.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace ROB.Data.Repositories
{
    public class ArmorRepository : BaseLinkRepository<ArmorModel>, IArmorRepository
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ArmorRepository(RealmDbContext context) : base(context) { }

        public async Task<IEnumerable<ArmorModel>> GetWithArmorRestorationAndRestrictionsAsync()
        {
            return await RealmDbContext.Armor
                .Include(a => a.ArmorRestoration)
                .Include(a => a.ArmorRestriction)
                .ToListAsync();
        }

        public async Task<IEnumerable<ArmorModel>> GetWithArmorRestorationAndRestrictionsByRestorationIdAsync(int id)
        {
            return await RealmDbContext.Armor
                .Include(a => a.ArmorRestoration)
                .Include(a => a.ArmorRestriction)
                .Where(a => a.ArmorRestorationId == id)
                .ToListAsync();
        }

        public async Task<IEnumerable<ArmorModel>> GetWithArmorRestorationAndRestrictionsByRestrictionIdAsync(int id)
        {
            return await RealmDbContext.Armor
                .Include(a => a.ArmorRestoration)
                .Include(a => a.ArmorRestriction)
                .Where(a => a.ArmorRestrictionId == id)
                .ToListAsync();
        }

        public async Task<ArmorModel> GetWithArmorRestorationAndRestrictionsByIdAsync(int id)
        {
            return await RealmDbContext.Armor
                .Include(a => a.ArmorRestoration)
                .Include(a => a.ArmorRestriction)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
    }
}
