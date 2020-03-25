using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
{
    public class ModifierModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public int? ChildSkillToModifyId { get; set; }
        [Display(Name = "Child Skill To Modify")]
        public ChildSkillModel ChildSkillToModify { get; set;} 

        public int? ParentSkillToModifyId { get; set; }
        [Display(Name = "Parent Skill To Modify")]
        public ParentSkillModel ParentSkillToModify { get; set; }

        public int? AttributeToModifyId { get; set; }
        [Display(Name = "Attribute To Modify")]
        public AttributeModel AttributeToModify { get; set; }

        [Display(Name = "Does it effect all parent skills?")]
        public bool EffectAllParentSkills { get; set; }

        [Display(Name = "Does it effect all trained parent skills?")]
        public bool EffectAllTrainedParentSkills { get; set; }

        [Display(Name = "Does it multiply by your current level?")]
        public bool MultiplyByLevel { get; set; }

        [Display(Name = "Additional Modifiers")]
        public string AdditionalModifiers { get; set; }

        public int Modifier { get; set; }

        [Display(Name = "Is this a new static modification?")]
        public bool IsStatic { get; set; }

        [Display(Name = "New static skill to modify eg. Night Vision (NV)")]
        public string StaticSkillToModify { get; set; }

        [Display(Name = "New static skill sufix to display eg. sq. FV or Exp")]
        public string StaticSkillSufix { get; set; }

        public ICollection<Modifier_Race_Link> Races { get; set; } = new List<Modifier_Race_Link>();
        public ICollection<Modifier_Technique_Link> Techniques { get; set; } = new List<Modifier_Technique_Link>();
    }
}
