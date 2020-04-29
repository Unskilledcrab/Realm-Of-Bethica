namespace ROB.Core.Models
{
    public class Quest_QuestTag_Link
    {
        public int QuestTagId { get; set; }
        public QuestTagModel QuestTag { get; set; }
        public int QuestId { get; set; }
        public QuestModel Quest { get; set; }
    }
}
