namespace ROBaspCore.Models
{
    public class CharacterSheet_QuestGroup_Link
    {
        public int QuestGroupId { get; set; }
        public QuestGroupModel QuestGroup { get; set; }
        public int CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
    }
}
