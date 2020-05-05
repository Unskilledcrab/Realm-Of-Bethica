using ROB.Web.Utilities;

namespace ROB.Web.Models
{
    public class CharacterAttributeModel : OwnableModifiableModelBase
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public AttributeModel Attribute { get; set; }
    }
}
