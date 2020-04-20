using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class CharacterSheet_Poison_Link_Configuration : IEntityTypeConfiguration<CharacterSheet_Poison_Link>
    {
        public void Configure(EntityTypeBuilder<CharacterSheet_Poison_Link> builder)
        {
            builder
                .HasKey(link => new { link.CharacterSheetId, link.PoisonId });

            builder
                .HasOne(link => link.CharacterSheet)
                .WithMany(classOne => classOne.Poisons)
                .HasForeignKey(link => link.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Poison)
                .WithMany(classTwo => classTwo.CharacterSheets)
                .HasForeignKey(link => link.PoisonId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
