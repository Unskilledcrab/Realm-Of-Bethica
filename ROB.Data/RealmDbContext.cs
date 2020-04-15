using Microsoft.EntityFrameworkCore;
using ROB.Core.Models;
using ROB.Data.Configurations;
using System;
using System.Reflection;

namespace ROB.Data
{
    public class RealmDbContext : DbContext
    {
        public DbSet<ArmorModel> Armor { get; set; }

        public RealmDbContext(DbContextOptions<RealmDbContext> options) : base(options) { }

        /// <summary>
        /// Gathers all configurations in the assembly and configures them
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {           
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
