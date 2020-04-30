using ROB.Blazor.Shared.Models.CombatEntities;

namespace ROB.Blazor.Shared.Interfaces
{
    public interface ICombatEntityActionHandler
    {
        int Mitigate(int magnitude, out int reflected);
        double CalculateAvoidance(CombatEntity entity);
        double GetMagnitudeModifier(CombatEntity entity);
    }
}
