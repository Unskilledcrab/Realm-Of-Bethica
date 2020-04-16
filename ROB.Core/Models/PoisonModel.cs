using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class PoisonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Effect { get; set; }
        public int Duration { get; set; }
        public int ConstitutionDamage { get; set; }
        public double Cost { get; set; }
        public int ClassId { get; set; }
        public PoisonClassModel Class { get; set; }
        public int TypeId { get; set; }
        public PoisonTypeModel Type { get; set; }

        public ICollection<CharacterSheet_Poison_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Poison_Link>();
        public ICollection<Building_Poison_Link> Buildings { get; set; } = new List<Building_Poison_Link>();
    }
}
