using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class CharacterSheet_Armor_Link_Configuration : IEntityTypeConfiguration<CharacterSheet_Armor_Link>
    {
        public void Configure(EntityTypeBuilder<CharacterSheet_Armor_Link> builder)
        {
            builder
                .HasKey(link => new { link.CharacterSheetId, link.ArmorId });

            builder
                .HasOne(link => link.CharacterSheet)
                .WithMany(classOne => classOne.Armors)
                .HasForeignKey(link => link.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Armor)
                .WithMany(classTwo => classTwo.CharacterSheets)
                .HasForeignKey(link => link.ArmorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
