using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class QuestRatingModel
    {
        public int Id { get; set; }
        [MaxLength(15, ErrorMessage = "Can not be more than 15 characters")]
        public string Rating { get; set; }
        /// <summary>
        /// This is the suggested level that the adverturers should be to go on this quest
        /// </summary>
        public int SuggestedLevel { get; set; }
        public string Description { get; set; }
        public ICollection<QuestModel> Quests { get; set; } = new List<QuestModel>();
    }
}
