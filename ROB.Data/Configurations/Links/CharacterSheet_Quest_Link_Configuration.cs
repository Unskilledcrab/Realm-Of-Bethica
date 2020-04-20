using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class CharacterSheet_Quest_Link_Configuration : IEntityTypeConfiguration<CharacterSheet_Quest_Link>
    {
        public void Configure(EntityTypeBuilder<CharacterSheet_Quest_Link> builder)
        {
            builder
                .HasKey(link => new { link.CharacterSheetId, link.QuestId });

            builder
                .HasOne(link => link.CharacterSheet)
                .WithMany(classOne => classOne.Quests)
                .HasForeignKey(link => link.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Quest)
                .WithMany(classTwo => classTwo.CharacterSheets)
                .HasForeignKey(link => link.QuestId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
