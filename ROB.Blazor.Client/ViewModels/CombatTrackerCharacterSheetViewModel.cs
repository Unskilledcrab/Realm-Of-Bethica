using ROB.Blazor.Client.Extensions;
using ROB.Blazor.Shared.Models;
using ROB.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ROB.Blazor.Client.ViewModels
{
    public class CombatTrackerCharacterSheetViewModel : CharacterSheetModel
    {
        public event Action TargetListChanged;
        public event Action TargetedStateChanged;
        public event Action FactionChanged;
        public event Action StatsChanged;
        public event Action<CombatTrackerCharacterSheetViewModel, CombatTrackerCharacterSheetViewModel, string> ActionPerformed;

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

        public CombatTrackerCharacterSheetViewModel()
        {
            // calculated
            Rct = new Stat() { Abbreviation = "Rct", Name = "Reaction Speed", Value = ((Agile + Knowledgeable) / 2.0).AsStat() };
            EVA = new Stat() { Abbreviation = "EVA", Name = "Evasion", Value = Agile + 10 + Level };
            AR = new Stat() { Abbreviation = "AR", Name = "Armor Rating", Value = Armors.Sum(x => x.Armor.DefenseRating) + Shields.Sum(x => x.Shield.DefensePoints) };
            PDR = new Stat() { Abbreviation = "PDR", Name = "Penetration Defense Rating", Value = Armors.Sum(x => x.Armor.PenetrationDefenseRating) + Shields.Sum(x => x.Shield.PenetrationDefenseRating) };
            HP = new Stat() { Abbreviation = "HP", Name = "Health Points", Value = (Strong + Robust + 1 + (int)Math.Floor(Robust / 5.0)) };

            // start at 0 always?
            RM = new Stat() { Abbreviation = "RM", Name = "Reaction Modifier", Value = 0 };
            Tmp = new Stat() { Abbreviation = "Tmp", Name = "Temporary Health", Value = 0 };
            Wnd = new Stat() { Abbreviation = "Wnd", Name = "Wound", Value = 0 };

            // nothing mentioned about size and reach; necessary?  I made up the size calculation. 6 foot, 150 lbs => size = 5
            Size = new Stat() { Abbreviation = "Size", Name = "Size", Value = ((HeightInches / 12.0 * Weight / 180.0) + ((int)Race.Size + 1) * 3.0).AsStat() };
            Reach = new Stat() { Abbreviation = "Reach", Name = "Reach", Value = Weapons.Max(x => x.Weapon.Range) };            
        }
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

        public string Dem { get => Race.Name; }
        public string PortraitURL { get; set; } = @"https://www.povertyalliance.org/wp-content/uploads/2019/03/Portrait_Placeholder.png";
        new public GenderType Gender { get { return Enum.TryParse(base.Gender, out GenderType result) ? result : GenderType.Unknown; } set { base.Gender = value.ToString(); } }

        //public List<Weapon> Weapons { get; set; } = new List<Weapon>();
        public List<string> Reactions { get; set; } = new List<string>();
        public List<string> Traits { get; set; } = new List<string>();
        public List<string> Actions { get; set; } = new List<string>();
        public List<string> Effects { get; set; } = new List<string>();
        public List<CombatTrackerCharacterSheetViewModel> Targets { get; private set; } = new List<CombatTrackerCharacterSheetViewModel>();
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

        public void AddTarget(CombatTrackerCharacterSheetViewModel character)
        {
            Targets.Add(character);
            TargetListChanged?.Invoke();
            character.UpdateTargetedState();
        }

        public void RemoveTarget(CombatTrackerCharacterSheetViewModel character)
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

            switch (Alignment)
            {
                case Alignment.Light:
                    return "white";
                case Alignment.Chaotic:
                    return "darkred";
                case Alignment.Neutral:
                    return "goldenrod";
                default:
                    return "blue";
            }
        }

        public void PerformAction(string str)
        {
            foreach (CombatTrackerCharacterSheetViewModel character in Targets)
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
