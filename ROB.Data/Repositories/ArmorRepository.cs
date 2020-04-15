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

        public Task AddToPlayerByIdAsync(string playerId, ArmorModel entity)
        {
            throw new NotImplementedException();
        }

        public ValueTask<ArmorModel> GetByIdWithPlayerByIdAsync(string playerId, int entityId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ArmorModel>> GetWithPlayerByIdAsync(string playerId)
        {
            throw new NotImplementedException();
        }

        public void RemoveFromPlayerById(string playerId, ArmorModel entity)
        {
            throw new NotImplementedException();
        }
    }
}
