namespace ROB.Blazor.Shared.Interfaces
{
    public interface ICombatEntity
    {
        string Name { get; set; }
        int Health { get; set; }

        // the return value is for reflected damage or reflected heals; 
        // the ICombatEntity that is targeted will calculate the final damage or healing by considering his own defenses
        int RecieveAction(IAction action);
    }
}
