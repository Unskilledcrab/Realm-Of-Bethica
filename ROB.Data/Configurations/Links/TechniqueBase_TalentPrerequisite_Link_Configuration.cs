using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class TechniqueBase_TalentPrerequisite_Link_Configuration : IEntityTypeConfiguration<TechniqueBase_TalentPrerequisite_Link>
    {
        public void Configure(EntityTypeBuilder<TechniqueBase_TalentPrerequisite_Link> builder)
        {
            builder
                .HasKey(link => new { link.TechniqueBaseId, link.TalentPrerequisiteId });

            builder
                .HasOne(link => link.TechniqueBase)
                .WithMany(classOne => classOne.TalentPrerequisites)
                .HasForeignKey(link => link.TechniqueBaseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.TalentPrerequisite)
                .WithMany(classTwo => classTwo.TechniqueBases)
                .HasForeignKey(link => link.TalentPrerequisiteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
