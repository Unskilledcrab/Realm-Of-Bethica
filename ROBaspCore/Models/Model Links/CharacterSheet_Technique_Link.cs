using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
{
    public class CharacterSheet_Technique_Link
    {
        public int? CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public int? TechniqueId { get; set; }
        public TechniqueModel Technique { get; set; }
    }
}
