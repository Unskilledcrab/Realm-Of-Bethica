using System.ComponentModel.DataAnnotations;

namespace ROBaspCore.Models
{
    public class WeaponSizeModel
    {
        public int Id { get; set; }
        [Display(Name = "Weapon Size")]
        [MaxLength(15, ErrorMessage = "Can not be more than 15 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        public double Type { get; set; }
        [Display(Name = "Damage Modifier")]
        public double DamageModifier { get; set; }
        [Display(Name = "Weight Modifier")]
        public double WeightModifier { get; set; }
    }
}
