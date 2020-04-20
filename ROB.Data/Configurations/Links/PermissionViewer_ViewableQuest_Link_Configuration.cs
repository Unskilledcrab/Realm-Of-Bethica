using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class PermissionViewer_ViewableQuest_Link_Configuration : IEntityTypeConfiguration<PermissionViewer_ViewableQuest_Link>
    {
        public void Configure(EntityTypeBuilder<PermissionViewer_ViewableQuest_Link> builder)
        {
            builder
                .HasKey(link => new { link.PermissionViewerId, link.ViewableQuestId });

            builder
                .HasOne(link => link.PermissionViewer)
                .WithMany(classOne => classOne.ViewableQuests)
                .HasForeignKey(link => link.PermissionViewerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.ViewableQuest)
                .WithMany(classTwo => classTwo.PermissionViewers)
                .HasForeignKey(link => link.ViewableQuestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
