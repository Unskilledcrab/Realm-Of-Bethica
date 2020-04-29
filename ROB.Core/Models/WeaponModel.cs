using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class WeaponModel
    {
        public int Id { get; set; }
        public int WeaponTypeId { get; set; }
        public WeaponTypeModel WeaponType { get; set; }
        public int SizeId { get; set; }
        public WeaponSizeModel Size { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public HandedTypeModel Handed { get; set; }
        public int RateOfAttack { get; set; }
        public int DamageValue { get; set; }
        public double DamageFactor { get; set; }
        public int DamageTypeId { get; set; }
        public DamageTypeModel DamageType { get; set; }
        public int ReactionModifier { get; set; }
        public int PenetrationValue { get; set; }
        public double Weight { get; set; }
        public int Range { get; set; }
        public double Cost { get; set; }
        public int Evasion { get; set; }
        public ICollection<CharacterSheet_Weapon_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Weapon_Link>();
        public ICollection<Building_Weapon_Link> Buildings { get; set; } = new List<Building_Weapon_Link>();
    }

    public enum HandedTypeModel
    {
        OneHanded,
        TwoHanded,
        Versatile
    }
}
