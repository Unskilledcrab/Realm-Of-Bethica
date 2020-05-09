using ROB.Blazor.Shared.Models;
using System;
using System.Collections.Generic;

namespace ROB.Blazor.Shared.Interfaces.CombatTracker
{
    public interface ICharacter
    {
        public enum FactionType
        {
            Friendly,
            Neutral,
            Hostile
        }
        public enum GenderType
        {
            Male,
            Female,
            Unknown
        }

        event Action TargetListChanged;
        event Action TargetedStateChanged;
        event Action FactionChanged;
        event Action StatsChanged;
        event Action<ICharacter, ICharacter, string> ActionPerformed;

        List<Stat> GetAttrStats();
        List<Stat> GetCharBarStats();
        List<Stat> GetAllStats();

        List<string> Reactions { get; set; }
        List<string> Traits { get; set; }
        List<string> Actions { get; set; }
        List<string> Effects { get; set; }
        List<ICharacter> Targets { get; set; }
        FactionType Faction { get; set; }

        int Id { get; set; }
        string Name { get; set; }
        string Dem { get; set; }
        string PortraitURL { get; set; }
        GenderType Gender { get; set; }
        Stat Rct { get; set; }
        Stat RM { get; set; }
        Stat EVA { get; set; }
        Stat AR { get; set; }
        Stat PDR { get; set; }
        Stat HP { get; set; }
        Stat Tmp { get; set; }
        Stat Wnd { get; set; }
        Stat Size { get; set; }
        Stat Reach { get; set; }
        Stat Toxic { get; set; }
        Stat Psychic { get; set; }

        void PerformAction(string str);
        void EndTurn();
        void UpdateFaction();
        void UpdateStats();
        void UpdateTargetedState();
        string PronounHisHer();
        string PronounHimselfHerself();
        string PronounHeShe();

        void AddTarget(ICharacter character);
        void RemoveTarget(ICharacter character);
        string GetFactionColor(bool hidden);
    }
}
