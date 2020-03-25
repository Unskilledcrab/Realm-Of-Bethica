namespace ROBaspCore.Models
{
    public class PermissionViewer_Quest_Link
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int QuestId { get; set; }
        public QuestModel Quest { get; set; }
    }
}
