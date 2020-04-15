namespace ROB.Core.Models
{
    public class Town_Building_Link
    {
        public int BuildingId { get; set; }
        public BuildingModel Building { get; set; }
        public int TownId { get; set; }
        public TownModel Town { get; set; }
    }
}
