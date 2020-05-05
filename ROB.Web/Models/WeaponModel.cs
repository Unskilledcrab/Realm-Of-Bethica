using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class WeaponModel
    {
        public int Id { get; set; }
        [Display(Name = "Weapon Type")]
        public int WeaponTypeId { get; set; }
        public WeaponTypeModel WeaponType { get; set; }
        public int SizeId { get; set; }
        public WeaponSizeModel Size { get; set; }

        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Hands used (one or two)")]
        public HandedTypeModel Handed { get; set; }
        [Display(Name = "Rate of Attack")]
        public int RateOfAttack { get; set; }
        [Display(Name = "Damage Value")]
        public int DamageValue { get; set; }
        [Display(Name = "Damage Factor")]
        public double DamageFactor { get; set; }
        public int DamageTypeId { get; set; }
        [Display(Name = "Damage Type")]
        public DamageTypeModel DamageType { get; set; }
        [Display(Name = "Reaction Modifier")]
        public int ReactionModifier { get; set; }
        [Display(Name = "Penetration Value")]
        public int PenetrationValue { get; set; }
        public double Weight { get; set; }
        public int Range { get; set; }
        [Display(Name = "Cost in Copper (cp)")]
        public double Cost { get; set; }
        public int Evasion { get; set; }
        public ICollection<CharacterSheet_Weapon_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Weapon_Link>();
        public ICollection<Building_Weapon_Link> Buildings { get; set; } = new List<Building_Weapon_Link>();
    }

    public enum HandedTypeModel
    {
        [Display(Name = "One Handed")]
        OneHanded,
        [Display(Name = "Two Handed")]
        TwoHanded,
        [Display(Name = "Versatile (Both)")]
        Versatile
    }
}
