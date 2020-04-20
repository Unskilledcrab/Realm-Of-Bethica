using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class CharacterSheetConfiguration : IEntityTypeConfiguration<CharacterSheetModel>
    {
        public void Configure(EntityTypeBuilder<CharacterSheetModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(150);

            builder
                .Property(b => b.Gender)
                .HasMaxLength(75);

            builder
                .Property(b => b.Faith)
                .HasMaxLength(1500);

            builder
                .Property(b => b.EyeColor)
                .HasMaxLength(45);

            builder
                .Property(b => b.HairColor)
                .HasMaxLength(45);

            builder
                .Property(b => b.SkinColor)
                .HasMaxLength(45);
        }
    }

}
