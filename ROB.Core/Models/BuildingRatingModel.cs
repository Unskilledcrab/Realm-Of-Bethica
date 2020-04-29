namespace ROB.Core.Models
{
    public class BuildingRatingModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Something like (Starter, Common, Uncommon, Rare, Very Rare, Legendary)
        /// Making it a class incase we ever want to add more
        /// </summary>
        public string Rating { get; set; }
        public string Description { get; set; }
    }
}
