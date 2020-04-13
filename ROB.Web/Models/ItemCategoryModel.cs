using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class ItemCategoryModel
    {
        public int Id { get; set; }
        [Display(Name = "Item Category")]
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
