using ROBaspCore.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
{
    public class CharacterAttributeModel : OwnableModifiableModelBase
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }
        public AttributeModel Attribute { get; set; }
    }
}
