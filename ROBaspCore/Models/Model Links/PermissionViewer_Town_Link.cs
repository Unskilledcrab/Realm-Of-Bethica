namespace ROBaspCore.Models
{
    public class PermissionViewer_Town_Link
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int TownId { get; set; }
        public TownModel Town { get; set; }
    }
}
