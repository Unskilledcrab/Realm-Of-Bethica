using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class QuestTagModel
    {
        public int Id { get; set; }
        [MaxLength(10, ErrorMessage = "Can not be more than 10 characters")]
        public string Title { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// Convert to this using System.Drawing.Color.ToArgb()
        /// Convert from this using System.Drawing.Color.FromArgb()
        /// </summary>
        public int Color { get; set; }
        public ICollection<Quest_QuestTag_Link> Quests { get; set; } = new List<Quest_QuestTag_Link>();
    }
}
