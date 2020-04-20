using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class TechniqueGroupTypeConfiguration : IEntityTypeConfiguration<TechniqueGroupTypeModel>
    {
        public void Configure(EntityTypeBuilder<TechniqueGroupTypeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.TechniqueGroupType)
                .HasMaxLength(75);
        }
    }

}
