using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class SpellAreaConfiguration : IEntityTypeConfiguration<SpellAreaModel>
    {
        public void Configure(EntityTypeBuilder<SpellAreaModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

        }
    }

}
