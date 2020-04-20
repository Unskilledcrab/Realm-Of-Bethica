using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class LanguageGroupTypeConfiguration : IEntityTypeConfiguration<LanguageGroupTypeModel>
    {
        public void Configure(EntityTypeBuilder<LanguageGroupTypeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.LanguageType)
                .HasMaxLength(75);
        }
    }

}
