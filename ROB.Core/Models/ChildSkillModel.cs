using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class ChildSkillModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentSkillId { get; set; }
        public ParentSkillModel ParentSkill { get; set; }
        public int Cost { get; set; } = 1;

        public ICollection<CharacterSheet_ChildSkill_Link> CharacterSheets { get; set; } = new List<CharacterSheet_ChildSkill_Link>();
        public ICollection<PregenProfessionArchetype_ChildSkill_Link> PregenProfessionArchetypes { get; set; } = new List<PregenProfessionArchetype_ChildSkill_Link>();
    }
}
