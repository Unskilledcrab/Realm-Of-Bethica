using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class TalentGroupTypeConfiguration : IEntityTypeConfiguration<TalentGroupTypeModel>
    {
        public void Configure(EntityTypeBuilder<TalentGroupTypeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.GroupName)
                .HasMaxLength(75);
        }
    }

}
