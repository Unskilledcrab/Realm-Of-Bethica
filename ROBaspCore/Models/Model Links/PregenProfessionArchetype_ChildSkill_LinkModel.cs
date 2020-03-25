using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
{
    public class PregenProfessionArchetype_ChildSkill_LinkModel
    {
        public int? PregenProfessionArchetypeId { get; set; }
        public PregenProfessionArchetypeModel PregenProfessionArchetype { get; set; }
        public int? ChildSkillId { get; set; }
        public ChildSkillModel ChildSkill { get; set; }
    }
}
