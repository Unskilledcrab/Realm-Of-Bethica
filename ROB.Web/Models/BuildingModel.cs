using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ROB.Web.Models
{
    public class BuildingModel
    {
        public int Id { get; set; }
        [MaxLength(25, ErrorMessage = "Can not be more than 25 characters")]
        public string Name { get; set; }
        public string Description { get; set; }
        public int? OwnerId { get; set; }
        public CharacterSheetModel BuildingOwner { get; set; }
        public int BuildingRatingId { get; set; }

        [Display(Name = "Building Rating")]
        public BuildingRatingModel BuildingRating { get; set; }

        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }

        [Display(Name = "Picture Path")]
        public string PicturePath { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastUpdate { get; set; }

        /// <summary>
        /// This is a list of permissions and the users in this list have access to see this
        /// </summary>
        public ICollection<PermissionViewer_Building_Link> PermissionViewers { get; set; } = new List<PermissionViewer_Building_Link>();
        public ICollection<Town_Building_Link> Towns { get; set; } = new List<Town_Building_Link>();
        public ICollection<Building_Item_Link> Items { get; set; } = new List<Building_Item_Link>();
        public ICollection<Building_Weapon_Link> Weapons { get; set; } = new List<Building_Weapon_Link>();
        public ICollection<Building_Armor_Link> Armors { get; set; } = new List<Building_Armor_Link>();
        public ICollection<Building_Shield_Link> Shields { get; set; } = new List<Building_Shield_Link>();
        public ICollection<Building_Poison_Link> Poisons { get; set; } = new List<Building_Poison_Link>();
    }
}
