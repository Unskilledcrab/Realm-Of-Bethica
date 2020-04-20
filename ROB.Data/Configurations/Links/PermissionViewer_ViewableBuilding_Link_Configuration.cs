using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class PermissionViewer_ViewableBuilding_Link_Configuration : IEntityTypeConfiguration<PermissionViewer_ViewableBuilding_Link>
    {
        public void Configure(EntityTypeBuilder<PermissionViewer_ViewableBuilding_Link> builder)
        {
            builder
                .HasKey(link => new { link.PermissionViewerId, link.ViewableBuildingId });

            builder
                .HasOne(link => link.PermissionViewer)
                .WithMany(classOne => classOne.ViewableBuildings)
                .HasForeignKey(link => link.PermissionViewerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.ViewableBuilding)
                .WithMany(classTwo => classTwo.PermissionViewers)
                .HasForeignKey(link => link.ViewableBuildingId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
