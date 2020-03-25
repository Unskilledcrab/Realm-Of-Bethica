using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROBaspCore.Models
{
    public class QuestGroupModel
    {
        public int Id { get; set; }
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Synopsis { get; set; }

        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; }

        public ICollection<QuestModel> Quests { get; set; } = new List<QuestModel>();
        /// <summary>
        /// This is a list of the character sheets that this quest is currently on
        /// </summary>
        public ICollection<CharacterSheet_QuestGroup_Link> CharacterSheets { get; set; } = new List<CharacterSheet_QuestGroup_Link>();
        /// <summary>
        /// This is a list of permissions and the users in this list have access to see this quest
        /// </summary>
        public ICollection<PermissionViewer_QuestGroup_Link> PermissionViewers { get; set; } = new List<PermissionViewer_QuestGroup_Link>();
    }
}
