namespace ROB.Core.Models
{
    public class CharacterSheet_Item_Link
    {
        public int CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public int ItemId { get; set; }
        public ItemModel Item { get; set; }
    }
}
