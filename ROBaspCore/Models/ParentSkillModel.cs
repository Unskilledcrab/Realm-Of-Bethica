using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
{
    public class ParentSkillModel
    {
        public int Id { get; set; }
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "First Attribute")]
        public AttributeModel FirstAttribute { get; set; }
        [Display(Name = "Second Attribute")]
        public AttributeModel SecondAttribute { get; set; }
        public int Cost { get; set; } = 3;
        public ICollection<ChildSkillModel> ChildSkills { get; set; }
        public ICollection<PregenProfessionArchetype_ParentSkill_LinkModel> PregenProfessionArchetypeLink { get; set; } = new List<PregenProfessionArchetype_ParentSkill_LinkModel>();
        public ICollection<CharacterSheet_ParentSkill_Link> CharacterSheets { get; set; } = new List<CharacterSheet_ParentSkill_Link>();

    }
}
