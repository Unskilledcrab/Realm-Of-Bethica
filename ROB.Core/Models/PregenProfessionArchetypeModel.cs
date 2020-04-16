using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class PregenProfessionArchetypeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PregenProfessionArchetype_ParentSkill_LinkModel> TrainedParentSkills { get; set; } = new List<PregenProfessionArchetype_ParentSkill_LinkModel>();
        public ICollection<PregenProfessionArchetype_ChildSkill_LinkModel> ChildSkills { get; set; } = new List<PregenProfessionArchetype_ChildSkill_LinkModel>();
        public ICollection<PregenProfessionArchetype_Technique_LinkModel> Techniques { get; set; } = new List<PregenProfessionArchetype_Technique_LinkModel>();
        public ICollection<PregenProfessionArchetype_Talent_LinkModel> Talents { get; set; } = new List<PregenProfessionArchetype_Talent_LinkModel>();
    }
}
