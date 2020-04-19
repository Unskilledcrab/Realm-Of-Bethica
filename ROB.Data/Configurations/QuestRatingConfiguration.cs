using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROB.Data.Configurations
{
    class QuestRatingConfiguration : IEntityTypeConfiguration<QuestRatingModel>
    {
        public void Configure(EntityTypeBuilder<QuestRatingModel> builder)
        {
            builder
                .HasMany(p => p.Quests)
                .WithOne(c => c.DifficultyRating)
                .HasForeignKey(c => c.DifficultyRatingId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .Property(p => p.Rating)
                .HasMaxLength(15);
        }
    }
}
