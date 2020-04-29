using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ROB.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Guild { get; set; }

        #region Viewing Permissions
        public ICollection<PermissionViewer_ViewableTown_Link> ViewableTowns { get; set; } = new List<PermissionViewer_ViewableTown_Link>();
        public ICollection<PermissionViewer_ViewableQuestGroup_Link> ViewableQuestGroups { get; set; } = new List<PermissionViewer_ViewableQuestGroup_Link>();
        public ICollection<PermissionViewer_ViewableQuest_Link> ViewableQuests { get; set; } = new List<PermissionViewer_ViewableQuest_Link>();
        public ICollection<PermissionViewer_ViewableWorld_Link> ViewableWorlds { get; set; } = new List<PermissionViewer_ViewableWorld_Link>();
        public ICollection<PermissionViewer_ViewableBuilding_Link> ViewableBuildings { get; set; } = new List<PermissionViewer_ViewableBuilding_Link>();
        public ICollection<PermissionViewer_ViewableCharacterSheet_Link> ViewableCharacterSheets { get; set; } = new List<PermissionViewer_ViewableCharacterSheet_Link>();
        #endregion

        #region Created By
        public ICollection<BuildingModel> CreatedBuildings { get; set; } = new List<BuildingModel>();
        public ICollection<TownModel> CreatedTowns { get; set; } = new List<TownModel>();
        public ICollection<QuestGroupModel> CreatedQuestGroups { get; set; } = new List<QuestGroupModel>();
        public ICollection<QuestModel> CreatedQuests { get; set; } = new List<QuestModel>();
        public ICollection<CharacterSheetModel> CreatedCharacterSheets { get; set; } = new List<CharacterSheetModel>();
        public ICollection<WorldModel> CreatedWorlds { get; set; } = new List<WorldModel>();
        #endregion
    }
}
