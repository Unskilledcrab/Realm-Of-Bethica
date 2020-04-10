using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
