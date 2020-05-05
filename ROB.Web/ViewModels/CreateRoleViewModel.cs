using System.ComponentModel.DataAnnotations;

namespace ROB.Web.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
