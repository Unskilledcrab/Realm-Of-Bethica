using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class Building_Shield_Link_Configuration : IEntityTypeConfiguration<Building_Shield_Link>
    {
        public void Configure(EntityTypeBuilder<Building_Shield_Link> builder)
        {
            builder
                .HasKey(link => new { link.BuildingId, link.ShieldId });

            builder
                .HasOne(link => link.Building)
                .WithMany(classOne => classOne.Shields)
                .HasForeignKey(link => link.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Shield)
                .WithMany(classTwo => classTwo.Buildings)
                .HasForeignKey(link => link.ShieldId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
