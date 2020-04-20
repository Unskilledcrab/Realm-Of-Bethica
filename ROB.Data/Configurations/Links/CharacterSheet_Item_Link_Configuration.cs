using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class CharacterSheet_Item_Link_Configuration : IEntityTypeConfiguration<CharacterSheet_Item_Link>
    {
        public void Configure(EntityTypeBuilder<CharacterSheet_Item_Link> builder)
        {
            builder
                .HasKey(link => new { link.CharacterSheetId, link.ItemId });

            builder
                .HasOne(link => link.CharacterSheet)
                .WithMany(classOne => classOne.Items)
                .HasForeignKey(link => link.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Item)
                .WithMany(classTwo => classTwo.CharacterSheets)
                .HasForeignKey(link => link.ItemId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
