using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ROB.Web.ViewModels
{
    public class TalentPrerequisiteData
    {
        public int TalentId { get; set; }
        public string TalentName { get; set; }
        public bool IsPrerequisite { get; set; }
        public int TalentGroupId { get; set; }
    }
}