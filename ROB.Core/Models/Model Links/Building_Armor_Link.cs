namespace ROB.Core.Models
{
    public class Building_Armor_Link
    {
        public int BuildingId { get; set; }
        public BuildingModel Building { get; set; }
        public int ArmorId { get; set; }
        public ArmorModel Armor { get; set; }
    }
}
