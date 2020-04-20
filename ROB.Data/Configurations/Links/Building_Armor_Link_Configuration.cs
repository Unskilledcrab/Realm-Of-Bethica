using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class Building_Armor_Link_Configuration : IEntityTypeConfiguration<Building_Armor_Link>
    {
        public void Configure(EntityTypeBuilder<Building_Armor_Link> builder)
        {
            builder
                .HasKey(link => new { link.BuildingId, link.ArmorId });

            builder
                .HasOne(link => link.Building)
                .WithMany(classOne => classOne.Armors)
                .HasForeignKey(link => link.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Armor)
                .WithMany(classTwo => classTwo.Buildings)
                .HasForeignKey(link => link.ArmorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
