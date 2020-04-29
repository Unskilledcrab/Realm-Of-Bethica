using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class ShieldModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DefensePoints { get; set; }
        public int PenetrationDefenseRating { get; set; }
        public int EvasionModifier { get; set; }
        public double Weight { get; set; }
        public double Cost { get; set; }

        public ICollection<CharacterSheet_Shield_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Shield_Link>();
        public ICollection<Building_Shield_Link> Buildings { get; set; } = new List<Building_Shield_Link>();
    }
}
