using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class CharacterAttributeConfiguration : IEntityTypeConfiguration<CharacterAttributeModel>
    {
        public void Configure(EntityTypeBuilder<CharacterAttributeModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

        }
    }

}
