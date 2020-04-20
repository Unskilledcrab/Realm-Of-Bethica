using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ROB.Core.Models;

namespace ROB.Data.Configurations.Links
{
    public class CharacterSheet_Weapon_Link_Configuration : IEntityTypeConfiguration<CharacterSheet_Weapon_Link>
    {
        public void Configure(EntityTypeBuilder<CharacterSheet_Weapon_Link> builder)
        {
            builder
                .HasKey(link => new { link.CharacterSheetId, link.WeaponId });

            builder
                .HasOne(link => link.CharacterSheet)
                .WithMany(classOne => classOne.Weapons)
                .HasForeignKey(link => link.CharacterSheetId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasOne(link => link.Weapon)
                .WithMany(classTwo => classTwo.CharacterSheets)
                .HasForeignKey(link => link.WeaponId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
