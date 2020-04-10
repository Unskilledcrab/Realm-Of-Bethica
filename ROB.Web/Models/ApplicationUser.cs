using Microsoft.AspNetCore.Identity;
using ROB.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web
{
    public class ApplicationUser : IdentityUser
    {
        public string Guild { get; set; }

        #region Viewing Permissions
        public ICollection<PermissionViewer_Town_Link> ViewableTowns { get; set; } = new List<PermissionViewer_Town_Link>();
        public ICollection<PermissionViewer_QuestGroup_Link> ViewableQuestGroups { get; set; } = new List<PermissionViewer_QuestGroup_Link>();
        public ICollection<PermissionViewer_Quest_Link> ViewableQuests { get; set; } = new List<PermissionViewer_Quest_Link>();
        public ICollection<PermissionViewer_World_Link> ViewableWorlds { get; set; } = new List<PermissionViewer_World_Link>();
        public ICollection<PermissionViewer_Building_Link> ViewableBuildings { get; set; } = new List<PermissionViewer_Building_Link>();
        public ICollection<PermissionViewer_CharacterSheet_Link> ViewableCharacterSheets { get; set; } = new List<PermissionViewer_CharacterSheet_Link>();
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
