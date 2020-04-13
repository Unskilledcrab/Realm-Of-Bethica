using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Models
{
    public class PregenProfessionArchetype_Talent_LinkModel
    {
        public int? PregenProfessionArchetypeId { get; set; }
        public PregenProfessionArchetypeModel PregenProfessionArchetype { get; set; }
        public int? TalentId { get; set; }
        public TalentModel Talent { get; set; }
    }
}
