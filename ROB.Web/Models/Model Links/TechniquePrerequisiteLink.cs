namespace ROB.Web.Models
{
    public class TechniquePrerequisiteLink
    {
        public int? TechniqueModelId { get; set; }
        public TechniqueModel Technique { get; set; }
        public int? PrerequisiteId { get; set; }
        public TechniqueModel Prerequisite { get; set; }
    }
}
