using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
{
    public class PregenProfessionArchetype_ParentSkill_LinkModel
    {
        public int? PregenProfessionArchetypeId { get; set; }
        public PregenProfessionArchetypeModel PregenProfessionArchetype { get; set; }
        public int? ParentSkillId { get; set; }
        public ParentSkillModel ParentSkill { get; set; }
    }
}
