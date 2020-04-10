namespace ROB.Web.Models
{
    public class PermissionViewer_World_Link
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int WorldId { get; set; }
        public WorldModel World { get; set; }
    }
}
