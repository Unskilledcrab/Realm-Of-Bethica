using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Models
{
    public class ShieldModel
    {
        public int Id { get; set; }
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "Defense Points")]
        public int DefensePoints { get; set; }

        [Display(Name = "Penetration Defense Rating")]
        public int PenetrationDefenseRating { get; set; }

        [Display(Name = "Evasion Modifier")]
        public int EvasionModifier { get; set; }
        public double Weight { get; set; }
        public double Cost { get; set; }
        public ICollection<CharacterSheet_Shield_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Shield_Link>();
        public ICollection<Building_Shield_Link> Buildings { get; set; } = new List<Building_Shield_Link>();
    }
}
