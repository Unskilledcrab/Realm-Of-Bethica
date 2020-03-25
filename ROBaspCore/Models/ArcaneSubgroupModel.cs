using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROBaspCore.Models
{
    public class ArcaneSubgroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Arcane Value")]
        public int ArcaneValue { get; set; }
        public int ArcaneSphereId { get; set; }
        [Display(Name = "Arcane Sphere")]
        public ArcaneSphereModel ArcaneSphere { get; set; }
        public ICollection<ArcaneSubgroup_ArcanePowerAttribute_Link> ElementsUsedIn { get; set; } = new List<ArcaneSubgroup_ArcanePowerAttribute_Link>();
    }
}
