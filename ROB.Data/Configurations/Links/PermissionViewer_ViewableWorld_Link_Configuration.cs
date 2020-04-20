using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class PermissionViewer_ViewableWorld_Link_Configuration : IEntityTypeConfiguration<PermissionViewer_ViewableWorld_Link>
    {
        public void Configure(EntityTypeBuilder<PermissionViewer_ViewableWorld_Link> builder)
        {
            builder
                .HasKey(link => new { link.PermissionViewerId, link.ViewableWorldId });

            builder
                .HasOne(link => link.PermissionViewer)
                .WithMany(classOne => classOne.ViewableWorlds)
                .HasForeignKey(link => link.PermissionViewerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.ViewableWorld)
                .WithMany(classTwo => classTwo.PermissionViewers)
                .HasForeignKey(link => link.ViewableWorldId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
