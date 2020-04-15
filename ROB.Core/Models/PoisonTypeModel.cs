using System.ComponentModel.DataAnnotations;

namespace ROB.Core.Models
{
    public class PoisonTypeModel
    {
        public int Id { get; set; }
        [Display(Name = "Poison Type Name")]
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
