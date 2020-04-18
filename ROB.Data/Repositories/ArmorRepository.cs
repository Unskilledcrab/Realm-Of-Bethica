using ROB.Core.Models;
using ROB.Core.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ROB.Data.Repositories
{
    public class ArmorRepository : BaseRepository<ArmorModel>, IArmorRepository
    {
        public ArmorRepository(RealmDbContext context) : base(context) { }

        private RealmDbContext RealmDbContext { get { return Context as RealmDbContext; } }
    }
}
