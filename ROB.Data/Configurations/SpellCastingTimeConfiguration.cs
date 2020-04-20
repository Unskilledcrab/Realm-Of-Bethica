using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class SpellCastingTimeConfiguration : IEntityTypeConfiguration<SpellCastingTimeModel>
    {
        public void Configure(EntityTypeBuilder<SpellCastingTimeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .HasMany(p => p.Spells)
                .WithOne(c => c.CastingTime)
                .HasForeignKey(c => c.CastingTimeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

}
