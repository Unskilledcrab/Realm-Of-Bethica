using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class BuildingRatingModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Something like (Starter, Common, Uncommon, Rare, Very Rare, Legendary)
        /// Making it a class incase we ever want to add more
        /// </summary>
        [MaxLength(15, ErrorMessage = "Can not be more than 15 characters")]
        public string Rating { get; set; }
        public string Description { get; set; }
    }
}
