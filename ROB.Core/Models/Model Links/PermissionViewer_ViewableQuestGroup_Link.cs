namespace ROB.Core.Models
{
    public class PermissionViewer_ViewableQuestGroup_Link
    {
        public int ViewableQuestGroupId { get; set; }
        public QuestGroupModel ViewableQuestGroup { get; set; }
        public string PermissionViewerId { get; set; }
        public ApplicationUser PermissionViewer { get; set; }
    }
}
