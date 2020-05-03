using ROB.Blazor.Shared.Interfaces.CombatTracker;

namespace ROB.Blazor.Shared.Models
{
    public class Stat : IStat
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int Value { get; set; }
    }
}
