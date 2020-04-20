namespace ROB.Core.Models
{
    public class PermissionViewer_ViewableTown_Link
    {
        public string PermissionViewerId { get; set; }
        public ApplicationUser PermissionViewer { get; set; }
        public int ViewableTownId { get; set; }
        public TownModel ViewableTown { get; set; }
    }
}
