using System;
using System.Collections.Generic;
using System.Text;
using static ROB.Blazor.Shared.Models.Character;

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

        List<IStat> GetAttrStats();
        List<IStat> GetCharBarStats();
        List<IStat> GetAllStats();

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
        IStat Rct { get; set; }
        IStat RM { get; set; }
        IStat EVA { get; set; }
        IStat AR { get; set; }
        IStat PDR { get; set; }
        IStat HP { get; set; }
        IStat Tmp { get; set; }
        IStat Wnd { get; set; }
        IStat Size { get; set; }
        IStat Reach { get; set; }
        IStat Toxic { get; set; }
        IStat Psychic { get; set; }

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
