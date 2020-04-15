using System.ComponentModel.DataAnnotations;

namespace ROB.Core.Models
{
    public class TalentGroupTypeModel
    {
        public int Id { get; set; }
        [Display(Name = "Talent Group Name")]
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string GroupName { get; set; }
        public string Description { get; set; }
    }
}
