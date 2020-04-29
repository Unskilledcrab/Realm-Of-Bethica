namespace ROB.Core.Models
{
    public class CharacterSheet_Poison_Link
    {
        public int CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public int PoisonId { get; set; }
        public PoisonModel Poison { get; set; }
    }
}
