using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class CharacterSheet_Shield_Link_Configuration : IEntityTypeConfiguration<CharacterSheet_Shield_Link>
    {
        public void Configure(EntityTypeBuilder<CharacterSheet_Shield_Link> builder)
        {
            builder
                .HasKey(link => new { link.CharacterSheetId, link.ShieldId });

            builder
                .HasOne(link => link.CharacterSheet)
                .WithMany(classOne => classOne.Shields)
                .HasForeignKey(link => link.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Shield)
                .WithMany(classTwo => classTwo.CharacterSheets)
                .HasForeignKey(link => link.ShieldId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
