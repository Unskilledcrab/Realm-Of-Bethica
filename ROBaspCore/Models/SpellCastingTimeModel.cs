using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROBaspCore.Models
{
    public class SpellCastingTimeModel
    {
        public int Id { get; set; }
        [Display(Name = "Casting Time Name")]
        public string Name { get; set; }
        public int ArcaneValue { get; set; }
        public string Description { get; set; }
        public ICollection<SpellModel> Spells { get; set; } = new List<SpellModel>();
    }
}
