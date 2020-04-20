using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class PregenProfessionArchetype_Talent_Link_Configuration : IEntityTypeConfiguration<PregenProfessionArchetype_Talent_Link>
    {
        public void Configure(EntityTypeBuilder<PregenProfessionArchetype_Talent_Link> builder)
        {
            builder
                .HasKey(link => new { link.PregenProfessionArchetypeId, link.TalentId });

            builder
                .HasOne(link => link.PregenProfessionArchetype)
                .WithMany(classOne => classOne.Talents)
                .HasForeignKey(link => link.PregenProfessionArchetypeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Talent)
                .WithMany(classTwo => classTwo.PregenProfessionArchetypes)
                .HasForeignKey(link => link.TalentId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
