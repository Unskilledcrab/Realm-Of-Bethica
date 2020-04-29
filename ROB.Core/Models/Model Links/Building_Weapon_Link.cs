namespace ROB.Core.Models
{
    public class Building_Weapon_Link
    {
        public int BuildingId { get; set; }
        public BuildingModel Building { get; set; }
        public int WeaponId { get; set; }
        public WeaponModel Weapon { get; set; }
    }
}
