using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class CharacterSheet_Talent_Link_Configuration : IEntityTypeConfiguration<CharacterSheet_Talent_Link>
    {
        public void Configure(EntityTypeBuilder<CharacterSheet_Talent_Link> builder)
        {
            builder
                .HasKey(link => new { link.CharacterSheetId, link.TalentId });

            builder
                .HasOne(link => link.CharacterSheet)
                .WithMany(classOne => classOne.Talents)
                .HasForeignKey(link => link.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Talent)
                .WithMany(classTwo => classTwo.CharacterSheets)
                .HasForeignKey(link => link.TalentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
