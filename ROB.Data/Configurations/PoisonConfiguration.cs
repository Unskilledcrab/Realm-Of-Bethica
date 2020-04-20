using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class PoisonConfiguration : IEntityTypeConfiguration<PoisonModel>
    {
        public void Configure(EntityTypeBuilder<PoisonModel> builder)
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
                .Property(b => b.Effect)
                .HasMaxLength(75);
        }
    }

}
