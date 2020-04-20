using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class Modifier_Race_Link_Configuration : IEntityTypeConfiguration<Modifier_Race_Link>
    {
        public void Configure(EntityTypeBuilder<Modifier_Race_Link> builder)
        {
            builder
                .HasKey(link => new { link.ModifierId, link.RaceId });

            builder
                .HasOne(link => link.Modifier)
                .WithMany(classOne => classOne.Races)
                .HasForeignKey(link => link.ModifierId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Race)
                .WithMany(classTwo => classTwo.Modifiers)
                .HasForeignKey(link => link.RaceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
