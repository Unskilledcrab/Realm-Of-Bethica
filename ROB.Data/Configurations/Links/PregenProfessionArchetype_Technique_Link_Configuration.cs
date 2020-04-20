using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class PregenProfessionArchetype_Technique_Link_Configuration : IEntityTypeConfiguration<PregenProfessionArchetype_Technique_Link>
    {
        public void Configure(EntityTypeBuilder<PregenProfessionArchetype_Technique_Link> builder)
        {
            builder
                .HasKey(link => new { link.PregenProfessionArchetypeId, link.TechniqueId });

            builder
                .HasOne(link => link.PregenProfessionArchetype)
                .WithMany(classOne => classOne.Techniques)
                .HasForeignKey(link => link.PregenProfessionArchetypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Technique)
                .WithMany(classTwo => classTwo.PregenProfessionArchetypes)
                .HasForeignKey(link => link.TechniqueId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
