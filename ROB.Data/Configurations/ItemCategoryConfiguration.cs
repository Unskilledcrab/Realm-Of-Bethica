using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategoryModel>
    {
        public void Configure(EntityTypeBuilder<ItemCategoryModel> builder)
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
