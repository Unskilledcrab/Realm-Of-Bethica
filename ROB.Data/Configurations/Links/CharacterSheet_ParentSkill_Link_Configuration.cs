using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class CharacterSheet_ParentSkill_Link_Configuration : IEntityTypeConfiguration<CharacterSheet_ParentSkill_Link>
    {
        public void Configure(EntityTypeBuilder<CharacterSheet_ParentSkill_Link> builder)
        {
            builder
                .HasKey(link => new { link.CharacterSheetId, link.ParentSkillId });

            builder
                .HasOne(link => link.CharacterSheet)
                .WithMany(classOne => classOne.ParentSkills)
                .HasForeignKey(link => link.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.ParentSkill)
                .WithMany(classTwo => classTwo.CharacterSheets)
                .HasForeignKey(link => link.ParentSkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
