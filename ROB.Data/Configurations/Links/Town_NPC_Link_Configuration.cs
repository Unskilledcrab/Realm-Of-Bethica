using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class Town_NPC_Link_Configuration : IEntityTypeConfiguration<Town_NPC_Link>
    {
        public void Configure(EntityTypeBuilder<Town_NPC_Link> builder)
        {
            builder
                .HasKey(link => new { link.NPCTownId, link.NPCId });

            builder
                .HasOne(link => link.NPCTown)
                .WithMany(classOne => classOne.NPCs)
                .HasForeignKey(link => link.NPCTownId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.NPC)
                .WithMany(classTwo => classTwo.NPCTowns)
                .HasForeignKey(link => link.NPCId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
