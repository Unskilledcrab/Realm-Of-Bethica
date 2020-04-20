using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class PregenProfessionArchetype_ChildSkill_Link_Configuration : IEntityTypeConfiguration<PregenProfessionArchetype_ChildSkill_Link>
    {
        public void Configure(EntityTypeBuilder<PregenProfessionArchetype_ChildSkill_Link> builder)
        {
            builder
                .HasKey(link => new { link.PregenProfessionArchetypeId, link.ChildSkillId });

            builder
                .HasOne(link => link.PregenProfessionArchetype)
                .WithMany(classOne => classOne.ChildSkills)
                .HasForeignKey(link => link.PregenProfessionArchetypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.ChildSkill)
                .WithMany(classTwo => classTwo.PregenProfessionArchetypes)
                .HasForeignKey(link => link.ChildSkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
