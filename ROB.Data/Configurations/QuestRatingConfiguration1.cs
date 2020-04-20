using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class QuestRatingConfiguration : IEntityTypeConfiguration<QuestRatingModel>
    {
        public void Configure(EntityTypeBuilder<QuestRatingModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Rating)
                .HasMaxLength(50);


            builder
                .HasMany(p => p.Quests)
                .WithOne(c => c.DifficultyRating)
                .HasForeignKey(c => c.DifficultyRatingId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

}
