using ROB.Blazor.Shared.Interfaces;
using ROB.Blazor.Shared.Models.CombatEntities;
using System;
using System.Collections.Generic;

namespace ROB.Blazor.Shared.Models.Actions
{
    public abstract class Action : IAction
    {
        public Action<string> LogToConsole;
        // whatever might be handled differently; magical could be broken up into different types (cold, fire, etc) - 
        // physical and magic could be broken into direct, damage over time, etc.
        public enum ActionType
        {
            None,
            Heal,
            Physical,
            Magical
        }

        public string Name { get; set; }
        public string StartMessage { get; set; }
        public string EndMessage { get; set; }
        public ActionType Type { get; set; }
        public double HitRoll { get; set; }

        private int _magnitude;

        private Random _random;

        public Action()
        {
            // the random object should probably be in a static class somewhere
            _random = new Random((int)DateTime.Now.ToOADate());
        }

        public void Process(CombatEntity source, List<CombatEntity> targets)
        {
            LogToConsole?.Invoke(StartMessage);

            CalculateHitRoll();

            int netReturn = 0;
            foreach (CombatEntity entity in targets)
                netReturn += ActionProcess(source, entity);

            LogToConsole?.Invoke(EndMessage);

            if (!netReturn.Equals(0))
                LogToConsole($"{source.Name} received {netReturn} {(netReturn > 0 ? "damage" : "healing")} from his targets and {(source.Health > 0 ? $"is left with {source.Health} health" : "has died")}.");
        }

        public abstract int ActionProcess(CombatEntity source, CombatEntity targets);

        public int CalculateMagnitude(double modifierStrength)
        {
            return Convert.ToInt32(Math.Round(_magnitude * modifierStrength));
        }

        private void CalculateHitRoll()
        {
            HitRoll =  _random.NextDouble();
        }
    }
}
