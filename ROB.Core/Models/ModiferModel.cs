using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class ModifierModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? ChildSkillToModifyId { get; set; }
        public ChildSkillModel ChildSkillToModify { get; set;} 
        public int? ParentSkillToModifyId { get; set; }
        public ParentSkillModel ParentSkillToModify { get; set; }
        public int? AttributeToModifyId { get; set; }
        public AttributeModel AttributeToModify { get; set; }
        public bool EffectAllParentSkills { get; set; }
        public bool EffectAllTrainedParentSkills { get; set; }
        public bool MultiplyByLevel { get; set; }
        public string AdditionalModifiers { get; set; }
        public int Modifier { get; set; }
        public bool IsStatic { get; set; }
        public string StaticSkillToModify { get; set; }
        public string StaticSkillSufix { get; set; }

        public ICollection<Modifier_Race_Link> Races { get; set; } = new List<Modifier_Race_Link>();
        public ICollection<Modifier_Technique_Link> Techniques { get; set; } = new List<Modifier_Technique_Link>();
    }
}
