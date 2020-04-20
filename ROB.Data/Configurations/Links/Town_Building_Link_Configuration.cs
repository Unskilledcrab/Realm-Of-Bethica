using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class Town_Building_Link_Configuration : IEntityTypeConfiguration<Town_Building_Link>
    {
        public void Configure(EntityTypeBuilder<Town_Building_Link> builder)
        {
            builder
                .HasKey(link => new { link.TownId, link.BuildingId });

            builder
                .HasOne(link => link.Town)
                .WithMany(classOne => classOne.Buildings)
                .HasForeignKey(link => link.TownId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Building)
                .WithMany(classTwo => classTwo.Towns)
                .HasForeignKey(link => link.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
