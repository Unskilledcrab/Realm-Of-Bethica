using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class PregenProfessionArchetype_ParentSkill_Link_Configuration : IEntityTypeConfiguration<PregenProfessionArchetype_ParentSkill_Link>
    {
        public void Configure(EntityTypeBuilder<PregenProfessionArchetype_ParentSkill_Link> builder)
        {
            builder
                .HasKey(link => new { link.PregenProfessionArchetypeId, link.ParentSkillId });

            builder
                .HasOne(link => link.PregenProfessionArchetype)
                .WithMany(classOne => classOne.ParentSkills)
                .HasForeignKey(link => link.PregenProfessionArchetypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.ParentSkill)
                .WithMany(classTwo => classTwo.PregenProfessionArchetypes)
                .HasForeignKey(link => link.ParentSkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
