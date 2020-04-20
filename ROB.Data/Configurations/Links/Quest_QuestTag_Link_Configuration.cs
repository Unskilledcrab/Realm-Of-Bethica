using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class Quest_QuestTag_Link_Configuration : IEntityTypeConfiguration<Quest_QuestTag_Link>
    {
        public void Configure(EntityTypeBuilder<Quest_QuestTag_Link> builder)
        {
            builder
                .HasKey(link => new { link.QuestId, link.QuestTagId });

            builder
                .HasOne(link => link.Quest)
                .WithMany(classOne => classOne.QuestTags)
                .HasForeignKey(link => link.QuestId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.QuestTag)
                .WithMany(classTwo => classTwo.Quests)
                .HasForeignKey(link => link.QuestTagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
