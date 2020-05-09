﻿using static ROB.Blazor.Shared.Interfaces.CombatTracker.ICharacter;

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
        public Stat Rct { get; set; }
        public Stat RM { get; set; }
        public Stat EVA { get; set; }
        public Stat AR { get; set; }
        public Stat PDR { get; set; }
        public Stat HP { get; set; }
        public Stat Tmp { get; set; }
        public Stat Wnd { get; set; }
        public Stat Size { get; set; }
        public Stat Reach { get; set; }
        public Stat Toxic { get; set; }
        public Stat Psychic { get; set; }



    }
}
