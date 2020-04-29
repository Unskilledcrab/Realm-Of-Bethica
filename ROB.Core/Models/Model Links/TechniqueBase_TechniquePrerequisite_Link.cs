namespace ROB.Core.Models
{
    public class TechniqueBase_TechniquePrerequisite_Link
    {
        public int TechniqueBaseId { get; set; }
        public TechniqueModel TechniqueBase { get; set; }
        public int TechniquePrerequisiteId { get; set; }
        public TechniqueModel TechniquePrerequisite { get; set; }
    }
}
