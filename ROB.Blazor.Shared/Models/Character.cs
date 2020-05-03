using ROB.Blazor.Shared.Interfaces.CombatTracker;
using System.Collections.Generic;
using static ROB.Blazor.Shared.Interfaces.CombatTracker.ICharacter;

namespace ROB.Blazor.Shared.Models
{
    public class Character
    {
        public FactionType Faction { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dem { get; set; }
        public string PortraitURL { get; set; }
        public GenderType Gender { get; set; }
        public IStat Rct { get; set; }
        public IStat RM { get; set; }
        public IStat EVA { get; set; }
        public IStat AR { get; set; }
        public IStat PDR { get; set; }
        public IStat HP { get; set; }
        public IStat Tmp { get; set; }
        public IStat Wnd { get; set; }
        public IStat Size { get; set; }
        public IStat Reach { get; set; }
        public IStat Toxic { get; set; }
        public IStat Psychic { get; set; }



    }
}
