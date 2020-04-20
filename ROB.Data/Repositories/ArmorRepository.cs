using ROB.Core.Models;
using ROB.Core.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ROB.Data.Repositories
{
    public class ArmorRepository : BaseLinkRepository<ArmorModel>
    {
        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
        public ArmorRepository(RealmDbContext context) : base(context) { }
    }

    public class test
    {
        private readonly RealmDbContext context;

        public test(RealmDbContext context)
        {
            this.context = context;
        }
        public async void test2()
        {
            var test = new ArmorRepository(context);
            var th = await test.GetPage();
            test.RemoveLink(new CharacterSheet_Armor_Link { ArmorId = 1, CharacterSheetId = 1 });
        }
    }
}
