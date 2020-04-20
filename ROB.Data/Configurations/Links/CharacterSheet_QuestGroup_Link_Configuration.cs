using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class CharacterSheet_QuestGroup_Link_Configuration : IEntityTypeConfiguration<CharacterSheet_QuestGroup_Link>
    {
        public void Configure(EntityTypeBuilder<CharacterSheet_QuestGroup_Link> builder)
        {
            builder
                .HasKey(link => new { link.CharacterSheetId, link.QuestGroupId });

            builder
                .HasOne(link => link.CharacterSheet)
                .WithMany(classOne => classOne.QuestGroups)
                .HasForeignKey(link => link.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.QuestGroup)
                .WithMany(classTwo => classTwo.CharacterSheets)
                .HasForeignKey(link => link.QuestGroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
