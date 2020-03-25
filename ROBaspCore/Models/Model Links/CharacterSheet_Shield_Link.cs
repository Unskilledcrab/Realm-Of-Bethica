namespace ROBaspCore.Models
{
    public class CharacterSheet_Shield_Link
    {
        public int CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public int ShieldId { get; set; }
        public ShieldModel Shield { get; set; }
    }
}
