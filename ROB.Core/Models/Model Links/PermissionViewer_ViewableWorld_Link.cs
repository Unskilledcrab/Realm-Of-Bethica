namespace ROB.Core.Models
{
    public class PermissionViewer_ViewableWorld_Link
    {
        public string PermissionViewerId { get; set; }
        public ApplicationUser PermissionViewer { get; set; }
        public int ViewableWorldId { get; set; }
        public WorldModel ViewableWorld { get; set; }
    }
}
