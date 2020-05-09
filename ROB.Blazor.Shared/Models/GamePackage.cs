using ROB.Blazor.Shared.Interfaces.CombatTracker;
using ROB.Blazor.Shared.ViewModels;
using System.Collections.Generic;

namespace ROB.Blazor.Shared.Models
{
    public class GamePackage : IGamePackage
    {
        public List<CharacterViewModel> Characters { get; set; }
    }
}
