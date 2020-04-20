using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class TalentModel
    {
        public int Id { get; set; }
        public int TalentGroupId { get; set; }
        public TalentGroupTypeModel TalentGroup { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Benefit { get; set; }
        public string Notes { get; set; }
        public int Cost { get; set; } = 1;

        public ICollection<TalentBase_TalentPrerequisite_Link> TalentPrerequisites { get; set; } = new List<TalentBase_TalentPrerequisite_Link>();
        public ICollection<TalentBase_TalentPrerequisite_Link> TalentBases { get; set; } = new List<TalentBase_TalentPrerequisite_Link>();
        public ICollection<TechniqueBase_TalentPrerequisite_Link> TechniqueBases { get; set; } = new List<TechniqueBase_TalentPrerequisite_Link>();
        public ICollection<PregenProfessionArchetype_Talent_Link> PregenProfessionArchetypes { get; set; } = new List<PregenProfessionArchetype_Talent_Link>();
        public ICollection<CharacterSheet_Talent_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Talent_Link>();

    }
}
