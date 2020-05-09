using ROB.Blazor.Shared.ViewModels;
using System.Collections.Generic;

namespace ROB.Blazor.Shared.Interfaces.CombatTracker
{
    public interface IGamePackage
    {
        public List<CharacterViewModel> Characters { get; set; }

    }
}
