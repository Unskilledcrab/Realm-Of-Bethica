namespace ROB.Core.Models
{
    public class TechniqueTalentPrerequisiteLink
    {
        public int? TalentId { get; set; }
        public TalentModel TalentPrerequisite { get; set; }
        public int? TechniqueId { get; set; }
        public TechniqueModel Technique { get; set; }
    }
}
