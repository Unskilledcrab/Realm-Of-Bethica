using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class SpellRangeConfiguration : IEntityTypeConfiguration<SpellRangeModel>
    {
        public void Configure(EntityTypeBuilder<SpellRangeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .HasMany(p => p.Spells)
                .WithOne(c => c.Range)
                .HasForeignKey(c => c.RangeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

}
