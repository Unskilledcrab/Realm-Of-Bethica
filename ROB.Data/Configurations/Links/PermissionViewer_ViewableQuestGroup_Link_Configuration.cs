using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class PermissionViewer_ViewableQuestGroup_Link_Configuration : IEntityTypeConfiguration<PermissionViewer_ViewableQuestGroup_Link>
    {
        public void Configure(EntityTypeBuilder<PermissionViewer_ViewableQuestGroup_Link> builder)
        {
            builder
                .HasKey(link => new { link.PermissionViewerId, link.ViewableQuestGroupId });

            builder
                .HasOne(link => link.PermissionViewer)
                .WithMany(classOne => classOne.ViewableQuestGroups)
                .HasForeignKey(link => link.PermissionViewerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.ViewableQuestGroup)
                .WithMany(classTwo => classTwo.PermissionViewers)
                .HasForeignKey(link => link.ViewableQuestGroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
