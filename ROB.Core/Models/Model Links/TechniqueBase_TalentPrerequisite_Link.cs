namespace ROB.Core.Models
{
    public class TechniqueBase_TalentPrerequisite_Link
    {
        public int TalentPrerequisiteId { get; set; }
        public TalentModel TalentPrerequisite { get; set; }
        public int TechniqueBaseId { get; set; }
        public TechniqueModel TechniqueBase { get; set; }
    }
}
