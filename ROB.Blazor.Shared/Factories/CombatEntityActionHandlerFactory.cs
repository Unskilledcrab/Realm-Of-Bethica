using ROB.Blazor.Shared.Interfaces;
using ROB.Blazor.Shared.Models.Actions;
using ROB.Blazor.Shared.Models.CombatEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static ROB.Blazor.Shared.Models.Actions.Action;

namespace ROB.Blazor.Shared.Factories
{
    public static class ActionProcessor //CombatEntityActionHandlerFactory
    {
        private static Dictionary<ActionType, Models.Actions.Action> _actions;

        private static void Initialize()
        {
            var allActionTypes = Assembly.GetAssembly(typeof(Models.Actions.Action)).GetTypes()
                .Where(x => typeof(Models.Actions.Action).IsAssignableFrom(x) && x.IsAbstract == false);

            foreach(var actionType in allActionTypes)
            {
                Models.Actions.Action action = Activator.CreateInstance(actionType) as Models.Actions.Action;
                _actions.Add(action.Type, action);
            }
        }

        public static void UseActionOnCharacter(CombatEntity source, CombatEntity target, ActionType actionType)
        {
            if (_actions == null)
                Initialize();

            var action = _actions[actionType];
            action.ActionProcess(source, target);
        }


        [Obsolete]
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
