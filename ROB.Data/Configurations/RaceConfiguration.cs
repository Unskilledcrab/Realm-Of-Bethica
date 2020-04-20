using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class RaceConfiguration : IEntityTypeConfiguration<RaceModel>
    {
        public void Configure(EntityTypeBuilder<RaceModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.DescriptionBrief)
                .HasMaxLength(150);

            builder
                .Property(b => b.HeightInches)
                .HasMaxLength(75);

            builder
                .Property(b => b.WeightLBS)
                .HasMaxLength(75);

            builder
                .Property(b => b.LifeSpanYears)
                .HasMaxLength(75);
        }
    }

}
