namespace ROB.Core.Models
{
    public class PermissionViewer_ViewableBuilding_Link
    {
        public string PermissionViewerId { get; set; }
        public ApplicationUser PermissionViewer { get; set; }
        public int ViewableBuildingId { get; set; }
        public BuildingModel ViewableBuilding { get; set; }
    }
}
