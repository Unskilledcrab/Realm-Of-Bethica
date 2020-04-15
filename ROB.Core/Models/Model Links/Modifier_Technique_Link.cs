namespace ROB.Core.Models
{
    public class Modifier_Technique_Link
    {
        public int ModifierId { get; set; }
        public ModifierModel Modifier { get; set; }
        public int TechniqueId { get; set; }
        public TechniqueModel Technique { get; set; }
    }
}
