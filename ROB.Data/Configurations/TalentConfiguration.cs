using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class TalentConfiguration : IEntityTypeConfiguration<TalentModel>
    {
        public void Configure(EntityTypeBuilder<TalentModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .HasMaxLength(150);

            builder
                .Property(b => b.Notes)
                .HasMaxLength(1500);
        }
    }

}
