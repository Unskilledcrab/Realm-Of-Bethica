namespace ROB.Core.Models
{
    public class WeaponSizeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Type { get; set; }
        public double DamageModifier { get; set; }
        public double WeightModifier { get; set; }
    }
}
