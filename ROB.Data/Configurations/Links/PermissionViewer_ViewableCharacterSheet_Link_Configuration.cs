using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class PermissionViewer_ViewableCharacterSheet_Link_Configuration : IEntityTypeConfiguration<PermissionViewer_ViewableCharacterSheet_Link>
    {
        public void Configure(EntityTypeBuilder<PermissionViewer_ViewableCharacterSheet_Link> builder)
        {
            builder
                .HasKey(link => new { link.PermissionViewerId, link.ViewableCharacterSheetId });

            builder
                .HasOne(link => link.PermissionViewer)
                .WithMany(classOne => classOne.ViewableCharacterSheets)
                .HasForeignKey(link => link.PermissionViewerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.ViewableCharacterSheet)
                .WithMany(classTwo => classTwo.PermissionViewers)
                .HasForeignKey(link => link.ViewableCharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
