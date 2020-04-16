using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class ArcaneSubgroupModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ArcaneValue { get; set; }
        public int ArcaneSphereId { get; set; }
        public ArcaneSphereModel ArcaneSphere { get; set; }
        public ICollection<ArcaneSubgroup_ArcanePowerAttribute_Link> ElementsUsedIn { get; set; } = new List<ArcaneSubgroup_ArcanePowerAttribute_Link>();
    }
}
