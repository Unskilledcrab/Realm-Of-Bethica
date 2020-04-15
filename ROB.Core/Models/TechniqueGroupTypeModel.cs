using System.ComponentModel.DataAnnotations;

namespace ROB.Core.Models
{
    public class TechniqueGroupTypeModel
    {
        public int Id { get; set; }

        [Display(Name = "Technique Group Type")]
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string TechniqueGroupType { get; set; }
        public string Description { get; set; }
    }
}
