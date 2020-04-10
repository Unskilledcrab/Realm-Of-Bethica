namespace ROB.Web.Models
{
    public class Building_Shield_Link
    {
        public int BuildingId { get; set; }
        public BuildingModel Building { get; set; }
        public int ShieldId { get; set; }
        public ShieldModel Shield { get; set; }
    }
}
