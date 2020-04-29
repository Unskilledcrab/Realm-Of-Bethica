namespace ROB.Core.Models
{
    public class PregenProfessionArchetype_Talent_Link
    {
        public int PregenProfessionArchetypeId { get; set; }
        public PregenProfessionArchetypeModel PregenProfessionArchetype { get; set; }
        public int TalentId { get; set; }
        public TalentModel Talent { get; set; }
    }
}
