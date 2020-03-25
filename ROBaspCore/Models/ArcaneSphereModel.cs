using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
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