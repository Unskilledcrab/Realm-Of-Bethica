using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROBaspCore.Models
{
    public class SpellRangeModel
    {
        public int Id { get; set; }
        [Display(Name = "Range Type")]
        public string Name { get; set; }
        [Display(Name = "Arcane Value")]
        public int ArcaneValue { get; set; }
        public string Description { get; set; }
        public ICollection<SpellModel> Spells { get; set; } = new List<SpellModel>();
    }
}
