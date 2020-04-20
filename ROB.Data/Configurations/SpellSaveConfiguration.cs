using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class SpellSaveConfiguration : IEntityTypeConfiguration<SpellSaveModel>
    {
        public void Configure(EntityTypeBuilder<SpellSaveModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .HasMany(p => p.Spells)
                .WithOne(c => c.Save)
                .HasForeignKey(c => c.SaveId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

}
