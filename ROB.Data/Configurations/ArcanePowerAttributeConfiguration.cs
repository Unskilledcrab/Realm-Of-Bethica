using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class ArcanePowerAttributeConfiguration : IEntityTypeConfiguration<ArcanePowerAttributeModel>
    {
        public void Configure(EntityTypeBuilder<ArcanePowerAttributeModel> builder)
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
                .Property(b => b.Type)
                .HasMaxLength(100);
            
            builder
                .Property(b => b.Effects)
                .HasMaxLength(200);
        }
    }

}
