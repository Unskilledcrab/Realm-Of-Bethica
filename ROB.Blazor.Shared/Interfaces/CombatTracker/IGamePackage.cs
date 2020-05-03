using System;
using System.Collections.Generic;
using System.Text;

namespace ROB.Blazor.Shared.Interfaces.CombatTracker
{
    public interface IGamePackage
    {
        List<ICharacter> GetCharacters(int gameId);

    }
}
