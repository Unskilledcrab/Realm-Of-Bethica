using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class Modifier_Technique_Link_Configuration : IEntityTypeConfiguration<Modifier_Technique_Link>
    {
        public void Configure(EntityTypeBuilder<Modifier_Technique_Link> builder)
        {
            builder
                .HasKey(link => new { link.ModifierId, link.TechniqueId });

            builder
                .HasOne(link => link.Modifier)
                .WithMany(classOne => classOne.Techniques)
                .HasForeignKey(link => link.ModifierId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Technique)
                .WithMany(classTwo => classTwo.Modifiers)
                .HasForeignKey(link => link.TechniqueId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
