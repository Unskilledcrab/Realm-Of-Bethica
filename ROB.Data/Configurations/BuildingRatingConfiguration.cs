using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations
{
    public class BuildingRatingConfiguration : IEntityTypeConfiguration<BuildingRatingModel>
    {
        public void Configure(EntityTypeBuilder<BuildingRatingModel> builder)
        {
            builder
                .HasKey(b => b.Id);

            builder
                .Property(b => b.Id)
                .UseIdentityColumn();

            builder
                .Property(b => b.Rating)
                .HasMaxLength(50);
        }
    }

}
