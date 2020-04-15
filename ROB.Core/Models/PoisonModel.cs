using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Core.Models
{
    public class PoisonModel
    {
        public int Id { get; set; }
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Name { get; set; }
        public string Description { get; set; }

        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Effect { get; set; }
        public int Duration { get; set; }
        [Display(Name = "Constitution Damage")]
        public int ConstitutionDamage { get; set; }
        [Display(Name = "Cost in Copper (cp)")]
        public double Cost { get; set; }
        [Display(Name = "Poison Class")]
        public int ClassId { get; set; }
        public PoisonClassModel Class { get; set; }
        public int TypeId { get; set; }
        public PoisonTypeModel Type { get; set; }
        public ICollection<CharacterSheet_Poison_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Poison_Link>();

        public ICollection<Building_Poison_Link> Buildings { get; set; } = new List<Building_Poison_Link>();
    }
}
