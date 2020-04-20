using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class SpellDurationConfiguration : IEntityTypeConfiguration<SpellDurationModel>
    {
        public void Configure(EntityTypeBuilder<SpellDurationModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .HasMany(p => p.Spells)
                .WithOne(c => c.Duration)
                .HasForeignKey(c => c.DurationId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

}
