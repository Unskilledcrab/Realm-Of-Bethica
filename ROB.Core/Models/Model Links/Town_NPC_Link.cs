namespace ROB.Core.Models
{
    public class Town_NPC_Link
    {
        public int CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public int TownId { get; set; }
        public TownModel Town { get; set; }
    }
}
