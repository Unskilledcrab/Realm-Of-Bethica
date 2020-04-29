using ROB.Blazor.Shared.Models;
using System;
using System.Collections.Generic;

namespace ROB.Blazor.Client.ViewModels
{
    public class CharacterViewModel : Character
    {
        public event Action TargetListChanged;
        public event Action TargetedStateChanged;
        public event Action FactionChanged;
        public event Action StatsChanged;
        public event Action<CharacterViewModel, CharacterViewModel, string> ActionPerformed;

        public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public List<string> Reactions { get; set; } = new List<string>();
        public List<string> Traits { get; set; } = new List<string>();
        public List<string> Actions { get; set; } = new List<string>();
        public List<string> Effects { get; set; } = new List<string>();
        public List<CharacterViewModel> Targets { get; private set; } = new List<CharacterViewModel>();
        public List<Stat> GetStats()
        {
            List<Stat> stats = new List<Stat>();

            stats.AddRange(new[]
            {
                AR, EVA, HP, PDR, RM, Tmp, Wnd
            });

            return stats;
        }

        public List<Stat> GetPrimaryStats()
        {
            List<Stat> stats = new List<Stat>();

            stats.AddRange(new[]
            {
                Rct, HP, Tmp, Wnd
            });

            return stats;
        }

        public List<Stat> GetAllStats()
        {
            List<Stat> stats = new List<Stat>();

            stats.AddRange(new[]
            {
                Rct, AR, EVA, HP, PDR, RM, Tmp, Wnd, Size, Reach
            });

            return stats;
        }

        public void AddTarget(CharacterViewModel character)
        {
            Targets.Add(character);
            TargetListChanged?.Invoke();
            character.UpdateTargetedState();
        }

        public void RemoveTarget(CharacterViewModel character)
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
            foreach (CharacterViewModel character in Targets)
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
