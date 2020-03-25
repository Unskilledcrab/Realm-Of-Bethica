using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
{
    public class PregenProfessionArchetype_Technique_LinkModel
    {
        public int? PregenProfessionArchetypeId { get; set; }
        public PregenProfessionArchetypeModel PregenProfessionArchetype { get; set; }
        public int? TechniqueId { get; set; }
        public TechniqueModel Technique { get; set; }
    }
}
