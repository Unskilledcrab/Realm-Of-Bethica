using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class Building_Item_Link_Configuration : IEntityTypeConfiguration<Building_Item_Link>
    {
        public void Configure(EntityTypeBuilder<Building_Item_Link> builder)
        {
            builder
                .HasKey(link => new { link.BuildingId, link.ItemId });

            builder
                .HasOne(link => link.Building)
                .WithMany(classOne => classOne.Items)
                .HasForeignKey(link => link.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Item)
                .WithMany(classTwo => classTwo.Buildings)
                .HasForeignKey(link => link.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
