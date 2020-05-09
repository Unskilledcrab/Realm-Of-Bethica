using ROB.Blazor.Shared.Interfaces.CombatTracker;
using ROB.Blazor.Shared.Models;
using ROB.Blazor.Shared.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ROB.Web.API.Campaign
{
    public class MockGamePackageFactory
    {
        private Dictionary<int, List<CharacterViewModel>> _charactersPackages = new Dictionary<int, List<CharacterViewModel>>();

        public MockGamePackageFactory()
        {
            int index = 0;
            List<CharacterViewModel> characters = new List<CharacterViewModel>();

            characters.Add(new CharacterViewModel()
            {
                Id = 0,
                Name = "John the Doe-stroyer",
                Dem = "Human",
                Faction = ICharacter.FactionType.Friendly,
                Gender = ICharacter.GenderType.Male,
                PortraitURL = "https://us.123rf.com/450wm/lnino87/lnino871710/lnino87171000006/88046593-stock-vector-man-with-beard-and-cap.jpg?ver=6",

                Actions = new List<string>() { "Doe-stroy enemy", "Go to mancave" },
                Traits = new List<string>() { "Mediocre", "Always drunk" },
                Reactions = new List<string>() { "Belligerent" },
                Effects = new List<string>() { "Bloated" },

                Rct = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Rct", Name = "Reaction", Value = 4 },
                AR = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "AR", Name = "Armor Rating", Value = 6 },
                EVA = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "EVA", Name = "Evasion", Value = 4 },
                HP = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "HP", Name = "Health Points", Value = 10 },
                PDR = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "PDR", Name = "Penetration Defense Rating", Value = 3 },
                RM = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "RM", Name = "Reaction Modifier", Value = 0 },
                Tmp = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Tmp", Name = "Temporary Health", Value = 5 },
                Wnd = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Wnd", Name = "Wound", Value = 7 },
                Toxic = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Tf", Name = "Toxic Fortitude", Value = 7 },
                Psychic = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Pf", Name = "Psychic Fortitude", Value = 7 },

                Size = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Size", Name = "Size", Value = 10 },
                Reach = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Reach", Name = "Reach", Value = 5 }
            });

            characters.Add(new CharacterViewModel()
            {
                Id = 1,
                Name = "John's wife",
                Dem = "Human",
                Faction = ICharacter.FactionType.Hostile,
                Gender = ICharacter.GenderType.Female,
                PortraitURL = @"https://media.istockphoto.com/vectors/female-warrior-vector-id503758620?k=6&m=503758620&s=612x612&w=0&h=Xe2ZS9Ik2t8hm1EPfY1laQfv1FjWr80cMJ7ZB_XMwGI=",

                Actions = new List<string>() { "Nag", "Ignore", "Overreact" },
                Traits = new List<string>() { "Pretty", "'Smart'", "Hysterical" },
                Reactions = new List<string>() { "Over-reactive" },
                Effects = new List<string>() { "Depressed" },

                Rct = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Rct", Name = "Reaction", Value = 7 },
                AR = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "AR", Name = "Armor Rating", Value = 6 },
                EVA = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "EVA", Name = "Evasion", Value = 4 },
                HP = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "HP", Name = "Health Points", Value = 10 },
                PDR = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "PDR", Name = "Penetration Defense Rating", Value = 3 },
                RM = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "RM", Name = "Reaction Modifier", Value = 0 },
                Tmp = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Tmp", Name = "Temporary Health", Value = 5 },
                Wnd = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Wnd", Name = "Wound", Value = 7 },
                Toxic = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Tf", Name = "Toxic Fortitude", Value = 7 },
                Psychic = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Pf", Name = "Psychic Fortitude", Value = 7 },

                Size = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Size", Name = "Size", Value = 6 },
                Reach = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Reach", Name = "Reach", Value = 10 }
            });

            characters.Add(new CharacterViewModel()
            {
                Id = 2,
                Name = "John's mother",
                Dem = "Human",
                Faction = ICharacter.FactionType.Neutral,
                Gender = ICharacter.GenderType.Female,
                PortraitURL = "https://media.istockphoto.com/vectors/grandmother-smokes-tobacco-pipe-grandma-smoking-pipe-vector-id1162153675?k=6&m=1162153675&s=612x612&w=0&h=X1HulkLnUOBTbNvIzxw7KREvxbcPObxYprSmZDYR3oA=",

                Actions = new List<string>() { "Underreact", "Pray wrath upon enemies", "Light one up" },
                Traits = new List<string>() { "Overlooks accomplishments", "Smokey lungs" },
                Reactions = new List<string>() { "Unresponsive" },
                Effects = new List<string>() { "Oblivious", "Forgetting" },

                Rct = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Rct", Name = "Reaction", Value = 1 },
                AR = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "AR", Name = "Armor Rating", Value = 6 },
                EVA = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "EVA", Name = "Evasion", Value = 4 },
                HP = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "HP", Name = "Health Points", Value = 10 },
                PDR = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "PDR", Name = "Penetration Defense Rating", Value = 3 },
                RM = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "RM", Name = "Reaction Modifier", Value = 0 },
                Tmp = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Tmp", Name = "Temporary Health", Value = 5 },
                Wnd = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Wnd", Name = "Wound", Value = 7 },
                Toxic = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Tf", Name = "Toxic Fortitude", Value = 7 },
                Psychic = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Pf", Name = "Psychic Fortitude", Value = 7 },

                Size = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Size", Name = "Size", Value = 20 },
                Reach = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Reach", Name = "Reach", Value = 3 }
            });

            characters.Add(new CharacterViewModel()
            {
                Id = 3,
                Name = "Bogusaurus Rex",
                Dem = "A dinosaur, obviously",
                Faction = ICharacter.FactionType.Hostile,
                Gender = ICharacter.GenderType.Unknown,
                PortraitURL = "https://thumbs.dreamstime.com/b/funny-cartoon-dinosaur-lizard-isolated-18954697.jpg",

                Actions = new List<string>() { "Chomp", "Haymaker", "Fail to blow fire" },
                Traits = new List<string>() { "Huge", "Thinks its a dragon", "Hungry" },
                Reactions = new List<string>() { "Barrell Roll" },
                Effects = new List<string>() { "Slowed" },

                Rct = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Rct", Name = "Reaction", Value = 2 },
                AR = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "AR", Name = "Armor Rating", Value = 9 },
                EVA = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "EVA", Name = "Evasion", Value = 2 },
                HP = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "HP", Name = "Health Points", Value = 25 },
                PDR = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "PDR", Name = "Penetration Defense Rating", Value = 1 },
                RM = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "RM", Name = "Reaction Modifier", Value = 1 },
                Tmp = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Tmp", Name = "Temporary Health", Value = 0 },
                Wnd = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Wnd", Name = "Wound", Value = 6 },
                Toxic = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Tf", Name = "Toxic Fortitude", Value = 7 },
                Psychic = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Pf", Name = "Psychic Fortitude", Value = 7 },

                Size = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Size", Name = "Size", Value = 40 },
                Reach = new ROB.Blazor.Shared.Models.Stat() { Abbreviation = "Reach", Name = "Reach", Value = 10 }
            });

            _charactersPackages[index++] = characters;
        }

        public async Task<GamePackage> GetGamePackage(int campaignId)
        {
            GamePackage package = null;

            //this is where the DB could be asked for the game deets
            await Task.Run(() => { package = new GamePackage() { Characters = _charactersPackages[campaignId] }; });

            return package;
        }
    }
}
