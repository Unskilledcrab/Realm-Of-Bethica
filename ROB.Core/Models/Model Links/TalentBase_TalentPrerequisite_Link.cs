namespace ROB.Core.Models
{
    public class TalentBase_TalentPrerequisite_Link
    {
        public int TalentBaseId { get; set; }
        public TalentModel TalentBase { get; set; }
        public int TalentPrerequisiteId { get; set; }
        public TalentModel TalentPrerequisite { get; set; }
    }
}
