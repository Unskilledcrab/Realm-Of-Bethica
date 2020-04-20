using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class AttributeConfiguration : IEntityTypeConfiguration<AttributeModel>
    {
        public void Configure(EntityTypeBuilder<AttributeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

        }
    }

}
