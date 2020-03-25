using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.Models
{
    public class TalentPrerequisiteLink
    {
        public int? TalentId { get; set; }
        public TalentModel Talent { get; set; }
        public int? PrerequisiteId { get; set; }
        public TalentModel Prerequisite { get; set; }
    }
}
