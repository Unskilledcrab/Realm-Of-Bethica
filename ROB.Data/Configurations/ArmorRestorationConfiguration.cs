using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class ArmorRestorationConfiguration : IEntityTypeConfiguration<ArmorRestorationModel>
    {
        public void Configure(EntityTypeBuilder<ArmorRestorationModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.ArmorStyle)
                .HasMaxLength(100);
        }
    }

}
