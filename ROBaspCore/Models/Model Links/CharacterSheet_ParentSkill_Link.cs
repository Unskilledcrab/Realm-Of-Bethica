using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
{
    public class CharacterSheet_ParentSkill_Link
    {
        public int? CharacterSheetId { get; set; }
        public CharacterSheetModel CharacterSheet { get; set; }
        public int? ParentSkillId { get; set; }
        public ParentSkillModel ParentSkill { get; set; }
    }
}
