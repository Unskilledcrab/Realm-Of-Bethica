using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class Building_Poison_Link_Configuration : IEntityTypeConfiguration<Building_Poison_Link>
    {
        public void Configure(EntityTypeBuilder<Building_Poison_Link> builder)
        {
            builder
                .HasKey(link => new { link.BuildingId, link.PoisonId });

            builder
                .HasOne(link => link.Building)
                .WithMany(classOne => classOne.Poisons)
                .HasForeignKey(link => link.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Poison)
                .WithMany(classTwo => classTwo.Buildings)
                .HasForeignKey(link => link.PoisonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
