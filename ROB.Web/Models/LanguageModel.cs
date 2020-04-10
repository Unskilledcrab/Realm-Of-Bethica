using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Models
{
    [Display(Name = "Language")]
    public class LanguageModel
    {
        public int Id { get; set; }

        [Display(Name = "Language Name")]
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string LanguageName { get; set; }

        public int GroupTypeId { get; set; } // Entity framework generates this automatically on the DB side but you still need in class
        [Display(Name = "Group Type")]
        public LanguageGroupTypeModel GroupType { get; set; }

        [Display(Name = "Type Name")]
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string TypeName { get; set; }

        [Display(Name = "Is this language written?")]
        public bool Written { get; set; } // Is this language a written language?
    }
}