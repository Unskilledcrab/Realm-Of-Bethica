using ROB.Blazor.Shared.Models.CombatEntities;
using System.Collections.Generic;
using static ROB.Blazor.Shared.Models.Actions.Action;

namespace ROB.Blazor.Shared.Interfaces
{
    public interface IAction
    {
        string Name { get; set; }
        ActionType Type { get; set; }
        double HitRoll { get; set; }
        int CalculateMagnitude(double modifierStrength);
        void Process(CombatEntity source, List<CombatEntity> targets);
    }
}
