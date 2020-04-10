namespace ROB.Web.Models
{
    public class PermissionViewer_QuestGroup_Link
    {
        public int QuestGroupId { get; set; }
        public QuestGroupModel QuestGroup { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
