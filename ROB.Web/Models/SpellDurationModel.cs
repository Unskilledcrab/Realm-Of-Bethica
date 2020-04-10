using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class SpellDurationModel
    {
        public int Id { get; set; }
        [Display(Name = "Duration Name")]
        public string Name { get; set; }
        public int ArcaneValue { get; set; }
        public string Description { get; set; }
        public ICollection<SpellModel> Spells { get; set; } = new List<SpellModel>();
    }
}
