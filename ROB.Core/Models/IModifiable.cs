namespace ROB.Core.Models
{
    public interface IModifiable
    {
        int GameId { get; set; }
        int OverriddenValue { get; set; }
        string VariableName { get; set; }
        string Expression { get; set; }
        int Priority { get; set; }
        bool DefaultEnabled { get; set; }
    }

    public abstract class ModifiableBase : IModifiable
    {
        public int GameId { get; set; }
        public int OverriddenValue { get; set; }
        public string VariableName { get; set; }
        public string Expression { get; set; }
        public int Priority { get; set; }
        public bool DefaultEnabled { get; set; }
    }
}
