using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class ArcanePowerAttributeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Tier { get; set; }
        public int ArcaneValue { get; set; }
        public int? DamageTypeId { get; set; }
        public DamageTypeModel DamageType { get; set; }
        public string Effects { get; set; }
        public string Description { get; set; }
        public ICollection<ArcaneSubgroup_ArcanePowerAttribute_Link> RequiredArcaneSubgroups { get; set; } = new List<ArcaneSubgroup_ArcanePowerAttribute_Link>();
        public ICollection<Spell_ArcanePowerAttribute_Link> Spells { get; set; } = new List<Spell_ArcanePowerAttribute_Link>();
    }
}