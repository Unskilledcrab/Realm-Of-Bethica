using System.ComponentModel.DataAnnotations;

namespace ROBaspCore.Models
{
    public class BuildingTypeModel
    {
        public int Id { get; set; }
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Building Specialization")]
        public BuildingSpecialtyModel BuildingSpecialty { get; set; }
    }
}
