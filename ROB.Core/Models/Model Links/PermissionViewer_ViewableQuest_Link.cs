namespace ROB.Core.Models
{
    public class PermissionViewer_ViewableQuest_Link
    {
        public string PermissionViewerId { get; set; }
        public ApplicationUser PermissionViewer { get; set; }
        public int ViewableQuestId { get; set; }
        public QuestModel ViewableQuest { get; set; }
    }
}
