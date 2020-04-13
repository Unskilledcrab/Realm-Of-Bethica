namespace ROB.Web.Models
{
    public class Building_Item_Link
    {
        public int BuildingId { get; set; }
        public BuildingModel Building { get; set; }
        public int ItemId { get; set; }
        public ItemModel Item { get; set; }
    }
}
