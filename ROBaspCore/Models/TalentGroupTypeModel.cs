using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
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
