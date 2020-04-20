namespace ROB.Core.Models
{
    public class PregenProfessionArchetype_Technique_Link
    {
        public int PregenProfessionArchetypeId { get; set; }
        public PregenProfessionArchetypeModel PregenProfessionArchetype { get; set; }
        public int TechniqueId { get; set; }
        public TechniqueModel Technique { get; set; }
    }
}
