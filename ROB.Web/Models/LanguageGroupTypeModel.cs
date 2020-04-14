using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class LanguageGroupTypeModel
    {
        public int Id { get; set; }

        [Display(Name = "Language Group Type")]
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string LanguageType { get; set; }

        public string Description { get; set; }
    }
}
