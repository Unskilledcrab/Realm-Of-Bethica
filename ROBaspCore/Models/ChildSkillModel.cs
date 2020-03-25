using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
{
    [Display(Name = "Child Skill")]
    public class ChildSkillModel
    {
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Can not be more than 50 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentSkillId { get; set; }
        [Display(Name = "Parent Skill")]
        public ParentSkillModel ParentSkill { get; set; }
        public int Cost { get; set; } = 1;

        public ICollection<CharacterSheet_ChildSkill_Link> CharacterSheets { get; set; } = new List<CharacterSheet_ChildSkill_Link>();
        public ICollection<PregenProfessionArchetype_ChildSkill_LinkModel> PregenProfessionArchetypeLink { get; set; } = new List<PregenProfessionArchetype_ChildSkill_LinkModel>();
    }
}
