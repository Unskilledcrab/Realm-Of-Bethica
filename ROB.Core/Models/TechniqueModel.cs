using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class TechniqueModel
    {
        public int Id { get; set; }
        public int TechniqueGroupTypeId { get; set; }
        public TechniqueGroupTypeModel TechniqueGroupType { get; set; }
        public string TechniqueName { get; set; }
        public string Description { get; set; }
        public DurationLengthType DurationLengthType { get; set; }
        public int Duration { get; set; }
        public string Notes { get; set; }
        public int Cost { get; set; } = 2;
        public int MinimumLevelRequirement { get; set; } = 0;

        public ICollection<TechniqueBase_TechniquePrerequisite_Link> TechniquePrerequisites { get; set; } = new List<TechniqueBase_TechniquePrerequisite_Link>();
        public ICollection<TechniqueBase_TechniquePrerequisite_Link> TechniqueBases { get; set; } = new List<TechniqueBase_TechniquePrerequisite_Link>();
        public ICollection<TechniqueBase_TalentPrerequisite_Link> TalentPrerequisites { get; set; } = new List<TechniqueBase_TalentPrerequisite_Link>();
        public ICollection<Modifier_Technique_Link> Modifiers { get; set; } = new List<Modifier_Technique_Link>();
        public ICollection<CharacterSheet_Technique_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Technique_Link>();
        public ICollection<PregenProfessionArchetype_Technique_Link> PregenProfessionArchetypes { get; set; } = new List<PregenProfessionArchetype_Technique_Link>();
    }

    public enum DurationLengthType
    {
        Seconds,
        Minutes,
        Hours,
        Days,
        Infinite,
        NA
    }
}
