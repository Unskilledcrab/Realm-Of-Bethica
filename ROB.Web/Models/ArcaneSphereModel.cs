using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class ArcaneSphereModel
    {
        public int Id { get; set; }
        [Display(Name = "Arcane Sphere Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<SpellModel> Spells { get; set; } = new List<SpellModel>();
        public ICollection<ArcaneSubgroupModel> ArcaneSubgroups { get; set; } = new List<ArcaneSubgroupModel>();
    }
}