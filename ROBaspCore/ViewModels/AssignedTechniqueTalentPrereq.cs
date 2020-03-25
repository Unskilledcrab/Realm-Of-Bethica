using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROBaspCore.ViewModels
{
    public class AssignedTechniqueTalentPrereq
    {
        public int TalentId { get; set; }
        public string TalentName { get; set; }
        public bool IsPrerequisite { get; set; }
    }
}
