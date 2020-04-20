using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class CharacterSheet_Technique_Link_Configuration : IEntityTypeConfiguration<CharacterSheet_Technique_Link>
    {
        public void Configure(EntityTypeBuilder<CharacterSheet_Technique_Link> builder)
        {
            builder
                .HasKey(link => new { link.CharacterSheetId, link.TechniqueId });

            builder
                .HasOne(link => link.CharacterSheet)
                .WithMany(classOne => classOne.Techniques)
                .HasForeignKey(link => link.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Technique)
                .WithMany(classTwo => classTwo.CharacterSheets)
                .HasForeignKey(link => link.TechniqueId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
