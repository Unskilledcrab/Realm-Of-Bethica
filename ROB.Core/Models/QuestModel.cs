using System;
using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class QuestModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Synopsis { get; set; }
        /// <summary>
        /// This is used to order the quest if it is placed in a quest group
        /// </summary>
        public int Order { get; set; }
        public int DifficultyRatingId { get; set; }
        public QuestRatingModel DifficultyRating { get; set; }
        public int QuestGroupId { get; set; }
        /// <summary>
        /// This is the quest group this quest belongs to. It can not belong to multiple quest groups
        /// </summary>
        public QuestGroupModel QuestGroup { get; set; }
        public bool IsPublic { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; }
        public ICollection<Quest_QuestTag_Link> QuestTags { get; set; } = new List<Quest_QuestTag_Link>();
        /// <summary>
        /// This is a list of the character sheets that this quest is currently on
        /// </summary>
        public ICollection<CharacterSheet_Quest_Link> CharacterSheets { get; set; } = new List<CharacterSheet_Quest_Link>();
        /// <summary>
        /// This is a list of permissions and the users in this list have access to see this quest
        /// </summary>
        public ICollection<PermissionViewer_Quest_Link> PermissionViewers { get; set; } = new List<PermissionViewer_Quest_Link>();
    }
}
