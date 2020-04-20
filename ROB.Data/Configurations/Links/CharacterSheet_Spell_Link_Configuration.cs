using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class CharacterSheet_Spell_Link_Configuration : IEntityTypeConfiguration<CharacterSheet_Spell_Link>
    {
        public void Configure(EntityTypeBuilder<CharacterSheet_Spell_Link> builder)
        {
            builder
                .HasKey(link => new { link.CharacterSheetId, link.SpellId });

            builder
                .HasOne(link => link.CharacterSheet)
                .WithMany(classOne => classOne.Spells)
                .HasForeignKey(link => link.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Spell)
                .WithMany(classTwo => classTwo.CharacterSheets)
                .HasForeignKey(link => link.SpellId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
