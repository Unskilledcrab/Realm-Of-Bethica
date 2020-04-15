using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Core.Models
{
    public class WorldModel
    {
        public int Id { get; set; }
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string PicturePath { get; set; }

        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; }
        public ICollection<TownModel> Towns { get; set; } = new List<TownModel>();
        public ICollection<PermissionViewer_World_Link> PermissionViewers { get; set; } = new List<PermissionViewer_World_Link>();
    }
}
