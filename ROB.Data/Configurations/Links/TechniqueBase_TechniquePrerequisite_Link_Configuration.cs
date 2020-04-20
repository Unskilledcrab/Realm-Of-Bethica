using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class TechniqueBase_TechniquePrerequisite_Link_Configuration : IEntityTypeConfiguration<TechniqueBase_TechniquePrerequisite_Link>
    {
        public void Configure(EntityTypeBuilder<TechniqueBase_TechniquePrerequisite_Link> builder)
        {
            builder
                .HasKey(link => new { link.TechniqueBaseId, link.TechniquePrerequisiteId });

            builder
                .HasOne(link => link.TechniqueBase)
                .WithMany(classOne => classOne.TechniquePrerequisites)
                .HasForeignKey(link => link.TechniqueBaseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.TechniquePrerequisite)
                .WithMany(classTwo => classTwo.TechniqueBases)
                .HasForeignKey(link => link.TechniquePrerequisiteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
