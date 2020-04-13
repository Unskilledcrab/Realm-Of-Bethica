using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class DamageTypeModel
    {
        public int Id { get; set; }

        [Display(Name = "Damage Type")]
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Name { get; set; }
        public DamageCategory Category { get; set; }
        public string Description { get; set; }
    }

    public enum DamageCategory
    {
        External,
        Internal,
        Spiritual
    }
}
