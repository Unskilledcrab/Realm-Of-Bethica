using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class Spell_ArcanePowerAttribute_Link_Configuration : IEntityTypeConfiguration<Spell_ArcanePowerAttribute_Link>
    {
        public void Configure(EntityTypeBuilder<Spell_ArcanePowerAttribute_Link> builder)
        {
            builder
                .HasKey(link => new { link.SpellId, link.ArcanePowerAttributeId });

            builder
                .HasOne(link => link.Spell)
                .WithMany(classOne => classOne.ArcanePowerAttributes)
                .HasForeignKey(link => link.SpellId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.ArcanePowerAttribute)
                .WithMany(classTwo => classTwo.Spells)
                .HasForeignKey(link => link.ArcanePowerAttributeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
