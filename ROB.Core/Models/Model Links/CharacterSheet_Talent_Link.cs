namespace ROB.Core.Models
{
    public class CharacterSheet_Talent_Link
    {
        public int? CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public int? TalentId { get; set; }
        public TalentModel Talent { get; set; }
    }
}
