using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class ArcaneSphereConfiguration : IEntityTypeConfiguration<ArcaneSphereModel>
    {
        public void Configure(EntityTypeBuilder<ArcaneSphereModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(100);

            builder
                .HasMany(p => p.Spells)
                .WithOne(c => c.ArcaneSphere)
                .HasForeignKey(c => c.ArcaneSphereId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasMany(p => p.ArcaneSubgroups)
                .WithOne(c => c.ArcaneSphere)
                .HasForeignKey(c => c.ArcaneSphereId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
