using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class ModifierConfiguration : IEntityTypeConfiguration<ModifierModel>
    {
        public void Configure(EntityTypeBuilder<ModifierModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

        }
    }

}
