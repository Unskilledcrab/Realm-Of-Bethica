using System;

namespace ROB.Core.Models
{
    public class CharacterAttributeModel : IOwnable, IModifiable
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public AttributeModel Attribute { get; set; }
        public int GameId { get; set; }
        public int OverriddenValue { get; set; }
        public string VariableName { get; set; }
        public string Expression { get; set; }
        public int Priority { get; set; }
        public bool DefaultEnabled { get; set; }
        public bool IsPublic { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
