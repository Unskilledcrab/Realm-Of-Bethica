using ROB.Blazor.Shared.Interfaces;

namespace ROB.Blazor.Shared.Factories
{
    public static class CombatEntityActionHandlerFactory
    {
        public static ICombatEntityActionHandler GetHandler(IAction action)
        {
            ICombatEntityActionHandler handler = null;

            switch (action.Type)
            {
                case Models.Actions.Action.ActionType.Heal:
                    //handler = new HealCombatEntityActionHandler();
                    break;
                case Models.Actions.Action.ActionType.Physical:
                    //handler = new PhysicalCombatEntityActionHandler();
                    break;
                case Models.Actions.Action.ActionType.Magical:
                    //handler = new MagicalCombatEntityActionHandler();
                    break;
                case Models.Actions.Action.ActionType.None:
                    //handler = new NoActionCombatEntityActionHandler(); // or throw an error
                    break;
            }

            return handler;
        }
    }
}
