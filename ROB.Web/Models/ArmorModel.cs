using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    /// <summary>
    /// This is the data storage model. The user side of things needs to account for the damage on the armor and repairing it and such
    /// </summary>
    public class ArmorModel
    {
        public int Id { get; set; }
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Name { get; set; } // things like padded, soft leather
        public string Description { get; set; }

        [Display(Name = "Defense Rating")]
        public int DefenseRating { get; set; }
        [Display(Name = "Penetration Defense Rating")]
        public int PenetrationDefenseRating { get; set; }
        public int ArmorRestrictionId { get; set; }

        [Display(Name = "Armor Restriction")]
        public ArmorRestrictionModel ArmorRestriction { get; set; }
        public int ArmorRestorationId { get; set; }

        [Display(Name = "Armor Restoration")]
        public ArmorRestorationModel ArmorRestoration { get; set; }
        public double Weight { get; set; }
        public double Cost { get; set; }
        public ICollection<CharacterSheet_Armor_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Armor_Link>();
        public ICollection<Building_Armor_Link> Buildings { get; set; } = new List<Building_Armor_Link>();
    }
}
