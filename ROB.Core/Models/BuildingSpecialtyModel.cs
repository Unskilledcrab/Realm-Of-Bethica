using System.ComponentModel.DataAnnotations;

namespace ROB.Core.Models
{
    public class BuildingSpecialtyModel
    {
        public int Id { get; set; }
        /// <summary>
        /// All, None, Weapons, Items, Tomes, Armor, Shields, Poisons
        /// making a class incase we ever want to add more
        /// </summary>
        [MaxLength(15, ErrorMessage = "Can not be more than 15 characters")]
        public string Specialty { get; set; }
        /// <summary>
        /// This will explain what the specialty does
        /// Example: Weapons will give you a 1.2x sell modifier to weapons & 5% off all weapon sales prices
        /// </summary>
        public string Description { get; set; }
    }
}
