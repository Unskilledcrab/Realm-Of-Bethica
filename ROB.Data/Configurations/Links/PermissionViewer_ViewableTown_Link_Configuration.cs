using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class PermissionViewer_ViewableTown_Link_Configuration : IEntityTypeConfiguration<PermissionViewer_ViewableTown_Link>
    {
        public void Configure(EntityTypeBuilder<PermissionViewer_ViewableTown_Link> builder)
        {
            builder
                .HasKey(link => new { link.PermissionViewerId, link.ViewableTownId });

            builder
                .HasOne(link => link.PermissionViewer)
                .WithMany(classOne => classOne.ViewableTowns)
                .HasForeignKey(link => link.PermissionViewerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.ViewableTown)
                .WithMany(classTwo => classTwo.PermissionViewers)
                .HasForeignKey(link => link.ViewableTownId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
