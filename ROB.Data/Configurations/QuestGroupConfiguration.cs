using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class QuestGroupConfiguration : IEntityTypeConfiguration<QuestGroupModel>
    {
        public void Configure(EntityTypeBuilder<QuestGroupModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Title)
                .HasMaxLength(75);


            builder
                .HasMany(p => p.Quests)
                .WithOne(c => c.QuestGroup)
                .HasForeignKey(c => c.QuestGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

}
