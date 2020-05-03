using ROB.Blazor.Shared.Interfaces.CombatTracker;
using ROB.Blazor.Shared.Models;
using System;
using System.Collections.Generic;
using static ROB.Blazor.Shared.Interfaces.CombatTracker.ICharacter;

namespace ROB.Blazor.Client.ViewModels
{
    public class CharacterViewModel : Character, ICharacter
    {
        public event Action TargetListChanged;
        public event Action TargetedStateChanged;
        public event Action FactionChanged;
        public event Action StatsChanged;
        public event Action<ICharacter, ICharacter, string> ActionPerformed;

        public List<string> Reactions { get; set; } = new List<string>();
        public List<string> Traits { get; set; } = new List<string>();
        public List<string> Actions { get; set; } = new List<string>();
        public List<string> Effects { get; set; } = new List<string>();
        public List<ICharacter> Targets { get; set; } = new List<ICharacter>();

        public List<IStat> GetAttrStats()
        {
            return new List<IStat>()
            {
                RM, EVA, AR, PDR, Size, Reach
            };
        }

        public List<IStat> GetCharBarStats()
        {
            return new List<IStat>()
            {
                Rct, HP, Tmp, Wnd, Toxic, Psychic
            };
        }

        public List<IStat> GetAllStats()
        {
            return new List<IStat>()
            {
                Rct, AR, EVA, HP, PDR, RM, Tmp, Wnd, Size, Reach
            };
        }

        public void AddTarget(ICharacter character)
        {
            Targets.Add(character);
            TargetListChanged?.Invoke();
            character.UpdateTargetedState();
        }

        public void RemoveTarget(ICharacter character)
        {
            Targets.Remove(character);
            TargetListChanged?.Invoke();
            character.UpdateTargetedState();
        }

        public void UpdateTargetedState()
        {
            TargetedStateChanged?.Invoke();
        }

        public void EndTurn()
        {
            Targets.Clear();
            TargetListChanged?.Invoke();
        }

        public string GetFactionColor(bool hidden)
        {
            if (hidden)
                return "black";

            switch (Faction)
            {
                case FactionType.Friendly:
                    return "green";
                case FactionType.Hostile:
                    return "darkred";
                case FactionType.Neutral:
                    return "goldenrod";
                default:
                    return "white";
            }
        }

        public void PerformAction(string str)
        {
            foreach (ICharacter character in Targets)
            {
                ActionPerformed?.Invoke(this, character, str);
            }
            Targets.Clear();
        }

        public void UpdateFaction()
        {
            FactionChanged?.Invoke();
        }

        public void UpdateStats()
        {
            StatsChanged?.Invoke();
        }

        public string PronounHisHer() { return Gender == GenderType.Male ? "his" : Gender == GenderType.Female ? "her" : "its"; }
        public string PronounHimselfHerself() { return Gender == GenderType.Male ? "himself" : Gender == GenderType.Female ? "herself" : "itself"; }
        public string PronounHeShe() { return Gender == GenderType.Male ? "he" : Gender == GenderType.Female ? "she" : "it"; }
    }
}
