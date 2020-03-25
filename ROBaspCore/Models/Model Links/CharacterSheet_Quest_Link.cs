namespace ROBaspCore.Models
{
    public class CharacterSheet_Quest_Link
    {
        public int CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public int QuestId { get; set; }
        public QuestModel Quest { get; set; }
    }
}
