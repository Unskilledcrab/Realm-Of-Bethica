using System.ComponentModel.DataAnnotations;

namespace ROB.Core.Models
{
    public class ArmorRestorationModel
    {
        public int Id { get; set; }

        [Display(Name = "Armor Style")]
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string ArmorStyle { get; set; }
        public string Description { get; set; }

        [Display(Name = "Damage Rating Restoration")]
        public int DamageRatingRestoration { get; set; }
        public double Cost { get; set; }

        [Display(Name = "Repair Time (hours)")]
        public int RepairTimeHours { get; set; }
    }
}
