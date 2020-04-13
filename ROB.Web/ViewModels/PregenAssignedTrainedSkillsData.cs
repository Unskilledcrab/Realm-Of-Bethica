using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.ViewModels
{
    public class PregenAssignedTrainedSkillsData
    {
        public int ParentSkillId { get; set; }
        public string ParentSkillName { get; set; }
        public bool IsAssigned { get; set; }
    }
}
