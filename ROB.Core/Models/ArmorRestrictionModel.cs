namespace ROB.Core.Models
{
    public class ArmorRestrictionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FeatValuePenalty { get; set; }
        public int CastingPenalty { get; set; }
        public int EvasionPenalty { get; set; }
        public int MovementPenalty { get; set; }
    }
}
