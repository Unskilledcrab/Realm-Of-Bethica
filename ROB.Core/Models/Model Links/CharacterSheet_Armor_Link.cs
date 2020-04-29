namespace ROB.Core.Models
{
    public class CharacterSheet_Armor_Link
    {
        public int CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public int ArmorId { get; set; }
        public ArmorModel Armor { get; set; }
    }
}
