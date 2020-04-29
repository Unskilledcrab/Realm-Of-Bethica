using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Models
{
    public class PUBConGameModel
    {
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public string Description { get; set; }
        public string GameType { get; set; }
        public int MinimumPlayers { get; set; }
        public int MaximumPlayers { get; set; }
        public DateTime EventDate { get; set; }
        public double EventDuration { get; set; }
        public string MessageToPlayers { get; set; }
        public string GameMaster { get; set; }
        public string DiscordChannel { get; set; }
        public string GameMasterDiscordName { get; set; }

        [Display(Name = "Is Public")]
        public bool IsPublic { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime CreationDateTime { get; set; } = DateTime.Now;
        public DateTime LastUpdate { get; set; }
        public ICollection<User_PUBConGame_Link> Players { get; set; } = new List<User_PUBConGame_Link>();
    }
}
