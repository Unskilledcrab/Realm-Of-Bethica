using ROB.Blazor.Shared.Factories;
using ROB.Blazor.Shared.Interfaces;
using System;

namespace ROB.Blazor.Shared.Models.CombatEntities
{
    public class CombatEntity : ICombatEntity
    {
        public Action<ICombatEntity> Death;
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxHealth { get; set; }
        public int Health { get; set; }
        public int Armor { get; set; }
        public int Resistance { get; set; }
        public int Evasion { get; set; }
        public double HealingMitigation { get; set; }
        public int HealReflect { get; set; }
        public int MagicalReflect { get; set; }
        public int PhysicalReflect { get; set; }

        private ICombatEntityActionHandler _actionHandler;

        public int RecieveAction(IAction action)
        {
            _actionHandler = CombatEntityActionHandlerFactory.GetHandler(action);

            if (_actionHandler.CalculateAvoidance(this) < action.HitRoll)
            {
                double magnitudeModifier = _actionHandler.GetMagnitudeModifier(this);
                int magnitude = action.CalculateMagnitude(magnitudeModifier);
                int netDamage = _actionHandler.Mitigate(magnitude, out int netReflect);

                ApplyDamage(netDamage);
                return netReflect;
            }
            else
            {
                return 0;
                //handle logging a miss somehow; maybe returning a ActionResult object instead of just an int.
            }
        }

        protected virtual void ApplyDamage(int magnitude)
        {
            Health = Math.Max(Math.Min(Health + magnitude, MaxHealth), 0);
            if (Health == 0)
                Die();
        }

        protected virtual void Die()
        {
            Death?.Invoke(this);
        }
    }
}
