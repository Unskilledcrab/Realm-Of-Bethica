using System.Collections.Generic;

namespace ROB.Core.Models
{
    /// <summary>
    /// This is the data storage model. The user side of things needs to account for the damage on the armor and repairing it and such
    /// </summary>
    public class ArmorModel
    {
        public int Id { get; set; }
        public string Name { get; set; } // things like padded, soft leather
        public string Description { get; set; }
        public int DefenseRating { get; set; }
        public int PenetrationDefenseRating { get; set; }
        public int ArmorRestrictionId { get; set; }
        public ArmorRestrictionModel ArmorRestriction { get; set; }
        public int ArmorRestorationId { get; set; }
        public ArmorRestorationModel ArmorRestoration { get; set; }
        public double Weight { get; set; }
        public double Cost { get; set; }
        public ICollection<CharacterSheet_Armor_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Armor_Link>();
        public ICollection<Building_Armor_Link> Buildings { get; set; } = new List<Building_Armor_Link>();
    }
}
