using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Web.ViewModels
{
    public class EditRoleViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Role name is required")]
        public string RoleName { get; set; }
        public List<string> Users { get; set; } = new List<string>();

    }
}
