using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class PregenProfessionArchetypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PregenProfessionArchetype_ParentSkill_Link> ParentSkills { get; set; } = new List<PregenProfessionArchetype_ParentSkill_Link>();
        public ICollection<PregenProfessionArchetype_ChildSkill_Link> ChildSkills { get; set; } = new List<PregenProfessionArchetype_ChildSkill_Link>();
        public ICollection<PregenProfessionArchetype_Technique_Link> Techniques { get; set; } = new List<PregenProfessionArchetype_Technique_Link>();
        public ICollection<PregenProfessionArchetype_Talent_Link> Talents { get; set; } = new List<PregenProfessionArchetype_Talent_Link>();
    }
}
