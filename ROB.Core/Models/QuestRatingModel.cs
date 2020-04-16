using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class QuestRatingModel
    {
        public int Id { get; set; }
        public string Rating { get; set; }
        /// <summary>
        /// This is the suggested level that the adverturers should be to go on this quest
        /// </summary>
        public int SuggestedLevel { get; set; }
        public string Description { get; set; }
        public ICollection<QuestModel> Quests { get; set; } = new List<QuestModel>();
    }
}
