using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class ParentSkillModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public AttributeModel FirstAttribute { get; set; }
        public AttributeModel SecondAttribute { get; set; }
        public int Cost { get; set; } = 3;
        public ICollection<ChildSkillModel> ChildSkills { get; set; }
        public ICollection<PregenProfessionArchetype_ParentSkill_LinkModel> PregenProfessionArchetypeLink { get; set; } = new List<PregenProfessionArchetype_ParentSkill_LinkModel>();
        public ICollection<CharacterSheet_ParentSkill_Link> CharacterSheets { get; set; } = new List<CharacterSheet_ParentSkill_Link>();

    }
}
