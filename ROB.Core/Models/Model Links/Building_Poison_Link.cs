namespace ROB.Core.Models
{
    public class Building_Poison_Link
    {
        public int BuildingId { get; set; }
        public BuildingModel Building { get; set; }
        public int PoisonId { get; set; }
        public PoisonModel Poison { get; set; }
    }
}
