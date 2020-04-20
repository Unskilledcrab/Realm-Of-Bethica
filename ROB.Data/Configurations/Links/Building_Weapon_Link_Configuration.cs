using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class Building_Weapon_Link_Configuration : IEntityTypeConfiguration<Building_Weapon_Link>
    {
        public void Configure(EntityTypeBuilder<Building_Weapon_Link> builder)
        {
            builder
                .HasKey(link => new { link.BuildingId, link.WeaponId });

            builder
                .HasOne(link => link.Building)
                .WithMany(classOne => classOne.Weapons)
                .HasForeignKey(link => link.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Weapon)
                .WithMany(classTwo => classTwo.Buildings)
                .HasForeignKey(link => link.WeaponId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
