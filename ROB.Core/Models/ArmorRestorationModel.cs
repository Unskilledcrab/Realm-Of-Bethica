namespace ROB.Core.Models
{
    public class ArmorRestorationModel
    {
        public int Id { get; set; }
        public string ArmorStyle { get; set; }
        public string Description { get; set; }
        public int DamageRatingRestoration { get; set; }
        public double Cost { get; set; }
        public int RepairTimeHours { get; set; }
    }
}
