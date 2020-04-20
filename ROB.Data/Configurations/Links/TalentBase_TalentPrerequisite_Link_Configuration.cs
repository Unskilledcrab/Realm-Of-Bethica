using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class TalentBase_TalentPrerequisite_Link_Configuration : IEntityTypeConfiguration<TalentBase_TalentPrerequisite_Link>
    {
        public void Configure(EntityTypeBuilder<TalentBase_TalentPrerequisite_Link> builder)
        {
            builder
                .HasKey(link => new { link.TalentBaseId, link.TalentPrerequisiteId });

            builder
                .HasOne(link => link.TalentBase)
                .WithMany(classOne => classOne.TalentPrerequisites)
                .HasForeignKey(link => link.TalentBaseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.TalentPrerequisite)
                .WithMany(classTwo => classTwo.TalentBases)
                .HasForeignKey(link => link.TalentPrerequisiteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
