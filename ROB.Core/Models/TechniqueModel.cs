﻿using System.Collections.Generic;

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

        public ICollection<TechniquePrerequisiteLink> TechniquePrerequisites { get; set; } = new List<TechniquePrerequisiteLink>();
        public ICollection<TechniquePrerequisiteLink> TechniqueBases { get; set; } = new List<TechniquePrerequisiteLink>();
        public ICollection<TechniqueTalentPrerequisiteLink> TalentPrerequisites { get; set; } = new List<TechniqueTalentPrerequisiteLink>();
        public ICollection<Modifier_Technique_Link> Modifiers { get; set; } = new List<Modifier_Technique_Link>();
        public ICollection<CharacterSheet_Technique_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Technique_Link>();
        public ICollection<PregenProfessionArchetype_Technique_LinkModel> PregenProfessionArchetypeLink { get; set; } = new List<PregenProfessionArchetype_Technique_LinkModel>();
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
