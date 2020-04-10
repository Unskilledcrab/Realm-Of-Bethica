using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.Models
{
    public class TechniquePrerequisiteLink
    {
        public int? TechniqueModelId { get; set; }
        public TechniqueModel Technique { get; set; }
        public int? PrerequisiteId { get; set; }
        public TechniqueModel Prerequisite { get; set; }
    }
}
