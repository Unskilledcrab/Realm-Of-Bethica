namespace ROB.Web.Models
{
    public class PermissionViewer_Building_Link
    {
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public int BuildingId { get; set; }
        public BuildingModel Building { get; set; }
    }
}
