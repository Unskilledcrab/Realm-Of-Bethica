using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class CharacterSheet_ChildSkill_Link_Configuration : IEntityTypeConfiguration<CharacterSheet_ChildSkill_Link>
    {
        public void Configure(EntityTypeBuilder<CharacterSheet_ChildSkill_Link> builder)
        {
            builder
                .HasKey(link => new { link.CharacterSheetId, link.ChildSkillId });

            builder
                .HasOne(link => link.CharacterSheet)
                .WithMany(classOne => classOne.ChildSkills)
                .HasForeignKey(link => link.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.ChildSkill)
                .WithMany(classTwo => classTwo.CharacterSheets)
                .HasForeignKey(link => link.ChildSkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
