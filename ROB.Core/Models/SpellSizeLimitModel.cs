using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Core.Models
{
    public class SpellSizeLimitModel
    {
        public int Id { get; set; }
        [Display(Name = "Size Limit Type")]
        public string Name { get; set; }
        public int ArcaneValue { get; set; }
        public string Description { get; set; }
        public ICollection<SpellModel> Spells { get; set; } = new List<SpellModel>();
    }
}
