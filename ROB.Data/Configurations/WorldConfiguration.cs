using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class WorldConfiguration : IEntityTypeConfiguration<WorldModel>
    {
        public void Configure(EntityTypeBuilder<WorldModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(75);

            builder
                .HasMany(p => p.Towns)
                .WithOne(c => c.World)
                .HasForeignKey(c => c.WorldId)
                .OnDelete(DeleteBehavior.ClientSetNull);

        }
    }

}
