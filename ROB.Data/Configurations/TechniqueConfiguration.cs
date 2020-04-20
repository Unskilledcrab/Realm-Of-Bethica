using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class TechniqueConfiguration : IEntityTypeConfiguration<TechniqueModel>
    {
        public void Configure(EntityTypeBuilder<TechniqueModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.TechniqueName)
                .HasMaxLength(150);

            builder
                .Property(b => b.Notes)
                .HasMaxLength(600);
        }
    }

}
