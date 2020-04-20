using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class PoisonClassConfiguration : IEntityTypeConfiguration<PoisonClassModel>
    {
        public void Configure(EntityTypeBuilder<PoisonClassModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(75);
        }
    }

}
