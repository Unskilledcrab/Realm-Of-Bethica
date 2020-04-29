using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class ArcaneSphereModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<SpellModel> Spells { get; set; } = new List<SpellModel>();
        public ICollection<ArcaneSubgroupModel> ArcaneSubgroups { get; set; } = new List<ArcaneSubgroupModel>();
    }
}