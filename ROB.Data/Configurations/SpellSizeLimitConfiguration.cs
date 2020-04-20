using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class SpellSizeLimitConfiguration : IEntityTypeConfiguration<SpellSizeLimitModel>
    {
        public void Configure(EntityTypeBuilder<SpellSizeLimitModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .HasMany(p => p.Spells)
                .WithOne(c => c.SizeLimit)
                .HasForeignKey(c => c.SizeLimitId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

}
