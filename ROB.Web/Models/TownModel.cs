using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class TownModel
    {
        public int Id { get; set; }
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Picture Path")]
        public string PicturePath { get; set; }
        public int WorldId { get; set; }
        public WorldModel World { get; set; }

        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; }
        /// <summary>
        /// This is a list of permissions and the users in this list have access to see this
        /// </summary>
        public ICollection<PermissionViewer_Town_Link> PermissionViewers { get; set; } = new List<PermissionViewer_Town_Link>();
        public ICollection<Town_Building_Link> Buildings { get; set; } = new List<Town_Building_Link>();
        public ICollection<Town_NPC_Link> NPCs { get; set; } = new List<Town_NPC_Link>();
    }
}
